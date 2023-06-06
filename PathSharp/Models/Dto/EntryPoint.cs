using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class EntryPoint
    {
        [JsonPropertyName("UniqueId")]
        public Guid UniqueId { get; set; }

        [JsonPropertyName("Path")]
        public string? Path { get; set; }

        [JsonPropertyName("InputArguments")]
        public string? InputArguments { get; set; }

        [JsonPropertyName("OutputArguments")]
        public string? OutputArguments { get; set; }

        [JsonPropertyName("DataVariation")]
        public DataVariation? DataVariation { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
