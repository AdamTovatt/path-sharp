using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Arguments
    {
        [JsonIgnore]
        public InputArgumentSpecification? Input { get { if (input == null) DeserializeRawInput(); return input; } }
        private InputArgumentSpecification? input;

        [JsonPropertyName("Input")]
        public string? RawInput { get; set; }

        [JsonPropertyName("Output")]
        public string? Output { get; set; }

        private void DeserializeRawInput()
        {
            if (string.IsNullOrEmpty(RawInput))
                return;

            input = JsonSerializer.Deserialize<InputArgumentSpecification>(RawInput);
        }
    }
}
