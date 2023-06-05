using PathSharp.Exceptions;
using PathSharp.Models.Path;
using PathSharp.Models.RequestBodies;

namespace PathSharp
{
    public class PathClient
    {
        public static readonly List<string> DefaultScope = new List<string> { "path" };

        public HttpClient HttpClient { get { return httpClient; } set { httpClient = value; } }
        private HttpClient httpClient;

        internal string token = string.Empty;

        public PathClient(string baseAdress, string orchestratorAddress)
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAdress);
        }

        public async Task Authorize(string clientSecret, string clientId, List<string> scope)
        {
            AuthorizationParameters authorizationParameters = new AuthorizationParameters(clientSecret, clientId, scope);

            HttpResponseMessage responseMessage = await httpClient.PostAsync(RequestAddress.Identity.Token, authorizationParameters.ToFormUrlEncodedContent());

            if (!responseMessage.IsSuccessStatusCode)
                throw new AuthorizeException(await responseMessage.Content.ReadAsStringAsync());

            token = await responseMessage.Content.ReadAsStringAsync();
        }

        public async Task<Job> GetJobAsync()
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}