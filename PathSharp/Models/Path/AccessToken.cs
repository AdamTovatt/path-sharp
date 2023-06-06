using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Path
{
    public class AccessToken
    {
        [JsonPropertyName("access_token")]
        public string? Value { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }

        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [JsonPropertyName("scope")]
        public string? Scope { get; set; }

        public bool ContainsEmptyValues { get { return string.IsNullOrEmpty(Value) || ExpiresIn == null || string.IsNullOrEmpty(TokenType) || string.IsNullOrEmpty(Scope); } }

        private readonly DateTime? createdAt;

        public bool IsExpired
        {
            get
            {
                if (ExpiresIn == null || createdAt == null)
                {
                    return true;
                }

                return DateTime.UtcNow > createdAt.Value.AddSeconds(ExpiresIn.Value - 10); // 10 seconds margin
            }
        }

        public AccessToken()
        {
            createdAt = DateTime.UtcNow;
        }

        public static AccessToken? FromJson(string json)
        {
            return JsonSerializer.Deserialize<AccessToken>(json);
        }
    }
}
