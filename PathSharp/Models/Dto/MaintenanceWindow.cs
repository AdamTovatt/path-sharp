using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class MaintenanceWindow
    {
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("jobStopStrategy")]
        public string? JobStopStrategy { get; set; }

        [JsonPropertyName("cronExpression")]
        public string? CronExpression { get; set; }

        [JsonPropertyName("timezoneId")]
        public string? TimezoneId { get; set; }

        [JsonPropertyName("duration")]
        public long Duration { get; set; }

        [JsonPropertyName("nextExecutionTime")]
        public DateTimeOffset NextExecutionTime { get; set; }
    }
}
