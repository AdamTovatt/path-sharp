using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class UpdatePolicy
    {
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("SpecificVersion")]
        public string? SpecificVersion { get; set; }
    }
}
