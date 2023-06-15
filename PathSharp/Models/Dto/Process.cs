using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Process
    {
        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("Arguments")]
        public Arguments? Arguments { get; set; }

        [JsonPropertyName("SupportsMultipleEntryPoints")]
        public bool SupportsMultipleEntryPoints { get; set; }

        [JsonPropertyName("MainEntryPointPath")]
        public string? MainEntryPointPath { get; set; }

        [JsonPropertyName("RequiresUserInteraction")]
        public bool RequiresUserInteraction { get; set; }

        [JsonPropertyName("IsAttended")]
        public bool? IsAttended { get; set; }

        [JsonPropertyName("TargetFramework")]
        public string? TargetFramework { get; set; }

        [JsonPropertyName("EntryPoints")]
        public List<EntryPoint>? EntryPoints { get; set; }

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Version")]
        public string? Version { get; set; }

        [JsonPropertyName("Key")]
        public string? Key { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Published")]
        public DateTimeOffset? Published { get; set; }

        [JsonPropertyName("IsLatestVersion")]
        public bool IsLatestVersion { get; set; }

        [JsonPropertyName("OldVersion")]
        public string? OldVersion { get; set; }

        [JsonPropertyName("ReleaseNotes")]
        public string? ReleaseNotes { get; set; }

        [JsonPropertyName("Authors")]
        public string? Authors { get; set; }

        [JsonPropertyName("ProjectType")]
        public string? ProjectType { get; set; }

        [JsonPropertyName("Tags")]
        public string? Tags { get; set; }

        [JsonPropertyName("IsCompiled")]
        public bool IsCompiled { get; set; }

        [JsonPropertyName("LicenseUrl")]
        public string? LicenseUrl { get; set; }

        [JsonPropertyName("ProjectUrl")]
        public string? ProjectUrl { get; set; }

        [JsonPropertyName("ResourceTags")]
        public List<ResourceTag>? ResourceTags { get; set; }

        [JsonPropertyName("Id")]
        public string? Id { get; set; }
    }
}
