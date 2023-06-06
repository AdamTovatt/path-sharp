using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class VideoRecordingSettings
    {
        [JsonPropertyName("VideoRecordingType")]
        public string? VideoRecordingType { get; set; }

        [JsonPropertyName("MaxDurationSeconds")]
        public long MaxDurationSeconds { get; set; }
    }
}
