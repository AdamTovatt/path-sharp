using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Arguments
    {
        [JsonIgnore]
        public InputArgumentSpecification Input { get {}

        [JsonPropertyName("Input")]
        public string? RawInput { get; set; }

        [JsonPropertyName("Output")]
        public string? Output { get; set; }
    }
}
