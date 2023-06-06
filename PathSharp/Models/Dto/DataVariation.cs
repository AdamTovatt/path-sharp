using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class DataVariation
    {
        [JsonPropertyName("Content")]
        public string? Content { get; set; }

        [JsonPropertyName("ContentType")]
        public string? ContentType { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
