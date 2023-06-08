using System.Text.Json;

namespace PathSharp.Models.Dto
{
    public class StartJobValidationResult
    {
        public bool IsValid { get; set; }
        public List<string>? Errors { get; set; }

        public static StartJobValidationResult? FromJson(string json)
        {
            return JsonSerializer.Deserialize<StartJobValidationResult>(json);
        }
    }
}