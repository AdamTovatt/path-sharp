using PathSharp.Exceptions;
using PathSharp.Models.Path;
using PathSharp.Models.RequestBodies;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

namespace PathSharp
{
    public class PathClient : IDisposable
    {
        public static readonly List<string> DefaultScope = new List<string> { "OR.Jobs" };

        public HttpClient HttpClient { get { return httpClient; } set { httpClient = value; } }
        private HttpClient httpClient;

        public bool IsAuthorized { get { return Token != null && !Token.IsExpired; } }

        public AccessToken? Token { get; set; }

        private string orchestratorAddress;
        private string organisationUnit;

        public PathClient(string baseAdress, string orchestratorAddress, string organizationUnit)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAdress);
            this.orchestratorAddress = orchestratorAddress;
            this.organisationUnit = organizationUnit;
        }

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
            else if(Token.ContainsEmptyValues)
                throw new AuthorizeException($"The request returned status code 200 but the token contained empty values after deserializing the json: {tokenJson}");
        }

        public async Task<Job> GetJobsAsync()
        {
            HttpResponseMessage responseMessage = await httpClient.SendAsync(CreateAuthorizedRequestMessage(HttpMethod.Get, RequestAddress.Jobs.Get));

            if (!responseMessage.IsSuccessStatusCode)
                throw new PathException(await responseMessage.Content.ReadAsStringAsync());

            string json = await responseMessage.Content.ReadAsStringAsync();

            return new Job();
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }

        private HttpRequestMessage CreateAuthorizedRequestMessage(HttpMethod httpMethod, string address, object? parameter = null)
        {
            if (Token == null || Token.TokenType == null)
                throw new AuthorizeException("Trying to create an authorized exception when the client is not authorized correctly. Maybe you have forgotten to call AuthorizeAsync()?");

            HttpRequestMessage requestMessage = new HttpRequestMessage(httpMethod, GetFullAddress(address, parameter));
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(Token.TokenType, Token.Value);
            requestMessage.Headers.Add("x-uipath-organizationunitid", organisationUnit);

            return requestMessage;
        }

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