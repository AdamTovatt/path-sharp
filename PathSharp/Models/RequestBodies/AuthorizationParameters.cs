using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PathSharp.Models.RequestBodies
{
    internal class AuthorizationParameters
    {
        public string GrantType { get; set; } = "client_credentials";
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string Scope { get; set; }

        internal AuthorizationParameters(string clientSecret, string clientId, List<string> scope) 
        {
            this.ClientSecret = clientSecret;
            this.ClientId = clientId;
            this.Scope = string.Join(" ", scope);
        }

        private string ToContentString()
        {
            Dictionary<string, string> dictionary = GetType().GetProperties().ToDictionary(prop => prop.Name, prop => prop.GetValue(this)?.ToString() ?? string.Empty);
            return string.Join("&", dictionary.Select(kvp => $"{Regex.Replace(kvp.Key, "(?<!^)([A-Z])", "_$1").ToLower()}={kvp.Value}"));
        }

        internal HttpContent ToFormUrlEncodedContent()
        {
            HttpContent content = new ByteArrayContent(Encoding.UTF8.GetBytes(ToContentString()));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
            return content;
        }
    }
}
