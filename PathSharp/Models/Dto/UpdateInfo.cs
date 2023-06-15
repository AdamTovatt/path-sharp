using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class UpdateInfo
    {
        [JsonPropertyName("updateStatus")]
        public string? UpdateStatus { get; set; }

        [JsonPropertyName("reason")]
        public string? Reason { get; set; }

        [JsonPropertyName("targetUpdateVersion")]
        public string? TargetUpdateVersion { get; set; }

        [JsonPropertyName("isCommunity")]
        public bool IsCommunity { get; set; }

        [JsonPropertyName("statusInfo")]
        public string? StatusInfo { get; set; }
    }
}
