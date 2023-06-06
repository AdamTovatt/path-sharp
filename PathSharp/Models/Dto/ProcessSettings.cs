using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class ProcessSettings
    {
        [JsonPropertyName("ErrorRecordingEnabled")]
        public bool ErrorRecordingEnabled { get; set; }

        [JsonPropertyName("Duration")]
        public long Duration { get; set; }

        [JsonPropertyName("Frequency")]
        public long Frequency { get; set; }

        [JsonPropertyName("Quality")]
        public long Quality { get; set; }

        [JsonPropertyName("AutoStartProcess")]
        public bool AutoStartProcess { get; set; }

        [JsonPropertyName("AlwaysRunning")]
        public bool AlwaysRunning { get; set; }
    }
}
