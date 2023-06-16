using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class InputArgumentSpecification
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("required")]
        public bool InputArgumentRequired { get; set; }

        [JsonPropertyName("hasDefault")]
        public bool HasDefault { get; set; }

        public static InputArgumentSpecification? FromJson(string json)
        {
            return JsonSerializer.Deserialize<InputArgumentSpecification>(json);
        }

        public static List<InputArgumentSpecification>? GetListFromJson(string json)
        {
            return JsonSerializer.Deserialize<List<InputArgumentSpecification>>(json);
        }
    }
}
