using PathSharp.Exceptions;
using PathSharp.Models.Path;
using PathSharp.Models.RequestBodies;
using System.Net.Http.Headers;
using System.Text;

namespace PathSharp
{
    public class PathClient : IDisposable
    {
        public static readonly List<string> DefaultScope = new List<string> { "OR.Jobs" };

        public HttpClient HttpClient { get { return httpClient; } set { httpClient = value; } }
        private HttpClient httpClient;

        public AccessToken? Token { get; set; }

        public PathClient(string baseAdress, string orchestratorAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAdress);
        }

        public async Task Authorize(string clientSecret, string clientId, List<string> scope)
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

        public async Task<Job> GetJobAsync()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}