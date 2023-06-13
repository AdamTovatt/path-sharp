using PathSharp.Helpers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PathSharp.Models.Dto
{
    public class Job
    {
        [JsonPropertyName("Key")]
        public Guid Key { get; set; }

        [JsonPropertyName("StartTime")]
        public DateTimeOffset? StartTime { get; set; }

        [JsonPropertyName("EndTime")]
        public DateTimeOffset? EndTime { get; set; }

        [JsonPropertyName("State")]
        public string? State { get; set; }

        [JsonPropertyName("JobPriority")]
        public string? JobPriority { get; set; }

        [JsonPropertyName("SpecificPriorityValue")]
        public long? SpecificPriorityValue { get; set; }

        [JsonPropertyName("Robot")]
        public Robot? Robot { get; set; }

        [JsonPropertyName("Release")]
        public Release? Release { get; set; }

        [JsonPropertyName("ResourceOverwrites")]
        public string? ResourceOverwrites { get; set; }

        [JsonPropertyName("Source")]
        public string? Source { get; set; }

        [JsonPropertyName("SourceType")]
        public string? SourceType { get; set; }

        [JsonPropertyName("BatchExecutionKey")]
        public Guid? BatchExecutionKey { get; set; }

        [JsonPropertyName("Info")]
        public string? Info { get; set; }

        [JsonPropertyName("CreationTime")]
        public DateTimeOffset CreationTime { get; set; }

        [JsonPropertyName("StartingScheduleId")]
        public long? StartingScheduleId { get; set; }

        [JsonPropertyName("ReleaseName")]
        public string? ReleaseName { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("InputArguments")]
        public string? InputArguments { get; set; }

        [JsonPropertyName("OutputArguments")]
        public string? OutputArguments { get; set; }

        [JsonPropertyName("HostMachineName")]
        public string? HostMachineName { get; set; }

        [JsonPropertyName("HasMediaRecorded")]
        public bool? HasMediaRecorded { get; set; }

        [JsonPropertyName("HasVideoRecorded")]
        public bool? HasVideoRecorded { get; set; }

        [JsonPropertyName("PersistenceId")]
        public Guid? PersistenceId { get; set; }

        [JsonPropertyName("ResumeVersion")]
        public long? ResumeVersion { get; set; }

        [JsonPropertyName("StopStrategy")]
        public string? StopStrategy { get; set; }

        [JsonPropertyName("RuntimeType")]
        public string? RuntimeType { get; set; }

        [JsonPropertyName("RequiresUserInteraction")]
        public bool? RequiresUserInteraction { get; set; }

        [JsonPropertyName("ReleaseVersionId")]
        public long? ReleaseVersionId { get; set; }

        [JsonPropertyName("EntryPointPath")]
        public string? EntryPointPath { get; set; }

        [JsonPropertyName("OrganizationUnitId")]
        public long? OrganizationUnitId { get; set; }

        [JsonPropertyName("OrganizationUnitFullyQualifiedName")]
        public string? OrganizationUnitFullyQualifiedName { get; set; }

        [JsonPropertyName("Reference")]
        public string? Reference { get; set; }

        [JsonPropertyName("ProcessType")]
        public string? ProcessType { get; set; }

        [JsonPropertyName("Machine")]
        public Machine? Machine { get; set; }

        [JsonPropertyName("ProfilingOptions")]
        public string? ProfilingOptions { get; set; }

        [JsonPropertyName("ResumeOnSameContext")]
        public bool? ResumeOnSameContext { get; set; }

        [JsonPropertyName("LocalSystemAccount")]
        public string? LocalSystemAccount { get; set; }

        [JsonPropertyName("OrchestratorUserIdentity")]
        public string? OrchestratorUserIdentity { get; set; }

        [JsonPropertyName("RemoteControlAccess")]
        public string? RemoteControlAccess { get; set; }

        [JsonPropertyName("MaxExpectedRunningTimeSeconds")]
        public int? MaxExpectedRunningTimeSeconds { get; set; }

        [JsonPropertyName("ServerlessJobType")]
        public string? ServerlessJobType { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }

        public static List<Job>? GetListFromJson(string json)
        {
            // the json from the api is wrapped in an object where there is a field called "value" which contains the actual json we want        
            return JsonSerializer.Deserialize<List<Job>>(json.GetJsonProperty("value"));
        }
    }
}