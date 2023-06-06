using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Release
    {
        [JsonPropertyName("Key")]
        public string? Key { get; set; }

        [JsonPropertyName("ProcessKey")]
        public string? ProcessKey { get; set; }

        [JsonPropertyName("ProcessVersion")]
        public string? ProcessVersion { get; set; }

        [JsonPropertyName("IsLatestVersion")]
        public bool IsLatestVersion { get; set; }

        [JsonPropertyName("IsProcessDeleted")]
        public bool IsProcessDeleted { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("EnvironmentId")]
        public long EnvironmentId { get; set; }

        [JsonPropertyName("EnvironmentName")]
        public string? EnvironmentName { get; set; }

        [JsonPropertyName("Environment")]
        public Environment? Environment { get; set; }

        [JsonPropertyName("EntryPointId")]
        public long EntryPointId { get; set; }

        [JsonPropertyName("EntryPoint")]
        public EntryPoint? EntryPoint { get; set; }

        [JsonPropertyName("InputArguments")]
        public string? InputArguments { get; set; }

        [JsonPropertyName("ProcessType")]
        public string? ProcessType { get; set; }

        [JsonPropertyName("SupportsMultipleEntryPoints")]
        public bool SupportsMultipleEntryPoints { get; set; }

        [JsonPropertyName("RequiresUserInteraction")]
        public bool RequiresUserInteraction { get; set; }

        [JsonPropertyName("IsAttended")]
        public bool IsAttended { get; set; }

        [JsonPropertyName("IsCompiled")]
        public bool IsCompiled { get; set; }

        [JsonPropertyName("AutomationHubIdeaUrl")]
        public string? AutomationHubIdeaUrl { get; set; }

        [JsonPropertyName("CurrentVersion")]
        public Version? CurrentVersion { get; set; }

        [JsonPropertyName("ReleaseVersions")]
        public List<Version>? ReleaseVersions { get; set; }

        [JsonPropertyName("Arguments")]
        public Arguments? Arguments { get; set; }

        [JsonPropertyName("ProcessSettings")]
        public ProcessSettings? ProcessSettings { get; set; }

        [JsonPropertyName("VideoRecordingSettings")]
        public VideoRecordingSettings? VideoRecordingSettings { get; set; }

        [JsonPropertyName("AutoUpdate")]
        public bool AutoUpdate { get; set; }

        [JsonPropertyName("FeedId")]
        public Guid FeedId { get; set; }

        [JsonPropertyName("JobPriority")]
        public string? JobPriority { get; set; }

        [JsonPropertyName("SpecificPriorityValue")]
        public long SpecificPriorityValue { get; set; }

        [JsonPropertyName("OrganizationUnitId")]
        public long OrganizationUnitId { get; set; }

        [JsonPropertyName("OrganizationUnitFullyQualifiedName")]
        public string? OrganizationUnitFullyQualifiedName { get; set; }

        [JsonPropertyName("TargetFramework")]
        public string? TargetFramework { get; set; }

        [JsonPropertyName("RobotSize")]
        public string? RobotSize { get; set; }

        [JsonPropertyName("Tags")]
        public List<Tag>? Tags { get; set; }

        [JsonPropertyName("RemoteControlAccess")]
        public string? RemoteControlAccess { get; set; }

        [JsonPropertyName("LastModificationTime")]
        public DateTimeOffset LastModificationTime { get; set; }

        [JsonPropertyName("LastModifierUserId")]
        public long LastModifierUserId { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("CreatorUserId")]
        public long CreatorUserId { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
