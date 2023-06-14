using PathSharp.Constants;
using PathSharp.Exceptions;
using PathSharp.Helpers;
using PathSharp.Models.Dto;
using PathSharp.Models.Path;
using PathSharp.Models.QueryParameters;
using PathSharp.Models.RequestBodies;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace PathSharp
{
    public class PathClient : IDisposable
    {
        /// <summary>
        /// The default scope for the PathClient
        /// </summary>
        public static readonly List<string> DefaultScope = new List<string> { "OR.Jobs", "OR.Folders.Read", "OR.Execution.Read", "OR.Robots.Read", "OR.Machines.Read" };

        /// <summary>
        /// The http client used for the requests
        /// </summary>
        public HttpClient HttpClient { get { return httpClient; } set { httpClient = value; } }
        private HttpClient httpClient;

        /// <summary>
        /// Wether or not the client is authorized, call AuthorizeAsync to authorize the client
        /// </summary>
        public bool IsAuthorized { get { return Token != null && !Token.IsExpired; } }

        /// <summary>
        /// The access token that the client has gotten from authorizing
        /// </summary>
        public AccessToken? Token { get; set; }

        private string orchestratorAddress;

        /// <summary>
        /// Constructor for the path client
        /// </summary>
        /// <param name="baseAdress">The base address to use, should be the domain to make requests to. Use the default value: RequestAddress.Base.Default if you are not sure what to use</param>
        /// <param name="orchestratorAddress">The orchestrator address is the part between the base address and the method specific addresses, it contains some sort of key and a name for the environment followed by "/orchestrator_"</param>
        public PathClient(string baseAdress, string orchestratorAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAdress);
            this.orchestratorAddress = orchestratorAddress;
        }

        /// <summary>
        /// Will authorize the client using the given parameters
        /// </summary>
        /// <param name="clientSecret">The client secret to use for authorization</param>
        /// <param name="clientId">The client id to use for authorization</param>
        /// <param name="scope">The scopes to request for the token</param>
        /// <returns>Nothing, it will just authorize the client instance</returns>
        /// <exception cref="AuthorizeException"></exception>
        public async Task AuthorizeAsync(string clientSecret, string clientId, List<string> scope)
        {
            AuthorizationParameters authorizationParameters = new AuthorizationParameters(clientSecret, clientId, scope);

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, RequestAddress.Identity.Token);
            requestMessage.Content = authorizationParameters.ToFormUrlEncodedContent();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new AuthorizeException(await responseMessage.Content.ReadAsStringAsync());

            string tokenJson = await responseMessage.Content.ReadAsStringAsync();
            Token = AccessToken.FromJson(tokenJson);

            if (Token == null)
                throw new AuthorizeException($"The request returned status code 200 but the token was null after deserializing the json: {tokenJson}");
            else if (Token.ContainsEmptyValues)
                throw new AuthorizeException($"The request returned status code 200 but the token contained empty values after deserializing the json: {tokenJson}");
        }
        
        /// <summary>
        /// Will validate a dynamic job start. Called with the same body that would be used to start a job and will return errors with that body
        /// </summary>
        /// <param name="body">The start job body for starting a job</param>
        /// <returns>Wether or not there were any errors with the start job body and information about those errors</returns>
        /// <exception cref="PathApiException">The api did not return a success status code</exception>
        public async Task<StartJobValidationResult?> ValidateDynamicJobAsync(StartJobBody body)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Post, RequestAddress.Jobs.ValidateDynamicJob);
            requestMessage.Content = body.ToJsonBody();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return StartJobValidationResult.FromJson(json);
        }

        /// <summary>
        /// Will start one or many jobs
        /// </summary>
        /// <param name="body">The body containing the paramters for starting the job or jobs</param>
        /// <returns>A list of jobs that were started</returns>
        /// <exception cref="PathApiException">The api did not return a success status code</exception>
        public async Task<List<Job>?> StartJobsAsync(StartJobBody body)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Post, RequestAddress.Jobs.StartJobs);
            requestMessage.Content = body.ToJsonBody();

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if(!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return Job.GetListFromJson(json);
        }

        /// <summary>
        /// Method for getting a list of jobs
        /// </summary>
        /// <param name="parameters">The optional parameters to use when getting the jobs</param>
        /// <returns>A list of jobs</returns>
        /// <exception cref="PathApiException">The api did not return a success status code</exception>
        public async Task<List<Job>?> GetJobsAsync(string organizationUnitId, ODataParameters? parameters = null)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Jobs.Get, queryParameters: parameters);
            requestMessage.AddOrganizationUnitId(organizationUnitId);
            
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return Job.GetListFromJson(json);
        }

        /// <summary>
        /// Will get a single job by id
        /// </summary>
        /// <param name="id">The id of the job to get</param>
        /// <param name="parameters">The optional parameters for when getting the job</param>
        /// <returns></returns>
        /// <exception cref="PathApiException"></exception>
        public async Task<Job?> GetJobAsync(long id, GetJobParameters? parameters = null)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Jobs.GetById, parameter: id, queryParameters: parameters);
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            return JsonSerializer.Deserialize<Job>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<List<Machine>?> GetMachinesAsync(ODataParameters? parameters = null)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Machines.Get, parameters);

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Machine>?>(json.GetJsonProperty("value"));
        }

        /// <summary>
        /// Will get all robots
        /// </summary>
        /// <param name="parameters">Optional parameters for the request</param>
        /// <returns>A list of robots</returns>
        /// <exception cref="PathApiException"></exception>
        public async Task<List<Robot>?> GetAllRobotsAsync(ODataParameters? parameters = null)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Robots.FindAll, parameters);

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Robot>?>(json.GetJsonProperty("value"));
        }

        /// <summary>
        /// Will get all robots in a folder with the given organizationUnitId
        /// </summary>
        /// <param name="organizationUnitId">The id of the folder to get the robots in. The id of a folder and organizationUnitId seems to be the same thing</param>
        /// <param name="parameters">Optional parameters for the request</param>
        /// <returns>A list with robots</returns>
        /// <exception cref="PathApiException"></exception>
        public async Task<List<Robot>?> GetRobotsAsync(string organizationUnitId, ODataParameters? parameters = null)
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Robots.Get, parameters);
            requestMessage.AddOrganizationUnitId(organizationUnitId);

            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Robot>?>(json.GetJsonProperty("value"));
        }

        /// <summary>
        /// Will get all folders. A folder id is needed in many requests as the header "x-uipath-organizationunitid".
        /// </summary>
        /// <returns>A list of folders</returns>
        /// <exception cref="PathApiException"></exception>
        public async Task<List<Folder>?> GetFoldersAsync()
        {
            HttpRequestMessage requestMessage = GetAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Folders.Get);
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathApiException(await responseMessage.Content.ReadAsStringAsync());

            return Folder.GetListFromJson(await responseMessage.Content.ReadAsStringAsync());
        }

        /// <summary>
        /// Will dispose the underlying http client
        /// </summary>
        public void Dispose()
        {
            httpClient?.Dispose();
        }

        /// <summary>
        /// Will create an authorized request message
        /// </summary>
        /// <param name="httpMethod">The http method to use</param>
        /// <param name="address">The address to use</param>
        /// <param name="parameter">Some addresses have a parameter in them like key in /odata/Jobs({key})/UiPath.Server.Configuration.OData.StopJob</param>
        /// <param name="queryParameters">If there are any additional query parameters</param>
        /// <returns></returns>
        /// <exception cref="AuthorizeException"></exception>
        public HttpRequestMessage GetAuthorizedRequestMessage(HttpMethod httpMethod, string address, QueryParameterCollection? queryParameters = null, object? parameter = null)
        {
            if (Token == null || Token.TokenType == null)
                throw new AuthorizeException("Trying to create an authorized exception when the client is not authorized correctly. Maybe you have forgotten to call AuthorizeAsync()?");

            string url = GetFullAddress(address, parameter);

            if (queryParameters != null)
                url = $"{url}?{queryParameters}";

            HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, url);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.Value);

            return requestMessage;
        }

        /// <summary>
        /// Will get the full address for a certain address, adding the parameter if needed
        /// </summary>
        /// <param name="address"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private string GetFullAddress(string address, object? parameter)
        {
            string? formattedAddress;

            if (orchestratorAddress.EndsWith('/')) // we remove the last / in case it is there
                orchestratorAddress.Substring(0, orchestratorAddress.Length - 1);

            if (parameter != null)
                formattedAddress = string.Format($"{orchestratorAddress}{address}", parameter);
            else
                formattedAddress = $"{orchestratorAddress}{address}";

            return formattedAddress;
        }
    }
}