using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Version
    {
        [JsonPropertyName("ReleaseId")]
        public long ReleaseId { get; set; }

        [JsonPropertyName("VersionNumber")]
        public string? VersionNumber { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("ReleaseName")]
        public string? ReleaseName { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
