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
        [JsonPropertyName("Input")]
        public string? Input { get; set; }

        [JsonPropertyName("Output")]
        public string? Output { get; set; }
    }
}
