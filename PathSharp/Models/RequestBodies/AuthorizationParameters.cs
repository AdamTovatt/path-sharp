using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathSharp.Models.RequestBodies
{
    internal class AuthorizationParameters
    {
        internal const string grantType = "client_credentials";
        internal string clientSecret { get; set; }
        internal string clientId { get; set; }
        internal string scope { get; set; }

        internal AuthorizationParameters(string clientSecret, string clientId, List<string> scope) 
        {
            this.clientSecret = clientSecret;
            this.clientId = clientId;
            this.scope = string.Join(" ", scope);
        }

        private Dictionary<string, string> ToDictionary()
        {
            return GetType().GetProperties().ToDictionary(prop => prop.Name, prop => prop.GetValue(this)?.ToString() ?? string.Empty);
        }

        internal FormUrlEncodedContent ToFormUrlEncodedContent()
        {
            return new FormUrlEncodedContent(ToDictionary());
        }
    }
}
