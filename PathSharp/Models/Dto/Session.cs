using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Session
    {
        [JsonPropertyName("ServiceUserName")]
        public string? ServiceUserName { get; set; }

        [JsonPropertyName("Robot")]
        public Robot? Robot { get; set; }

        [JsonPropertyName("HostMachineName")]
        public string? HostMachineName { get; set; }

        [JsonPropertyName("MachineId")]
        public long? MachineId { get; set; }

        [JsonPropertyName("MachineName")]
        public string? MachineName { get; set; }

        [JsonPropertyName("State")]
        public string? State { get; set; }

        [JsonPropertyName("Job")]
        public Job? Job { get; set; }

        [JsonPropertyName("ReportingTime")]
        public DateTimeOffset? ReportingTime { get; set; }

        [JsonPropertyName("Info")]
        public string? Info { get; set; }

        [JsonPropertyName("IsUnresponsive")]
        public bool IsUnresponsive { get; set; }

        [JsonPropertyName("LicenseErrorCode")]
        public string? LicenseErrorCode { get; set; }

        [JsonPropertyName("OrganizationUnitId")]
        public long? OrganizationUnitId { get; set; }

        [JsonPropertyName("FolderName")]
        public string? FolderName { get; set; }

        [JsonPropertyName("RobotSessionType")]
        public string? RobotSessionType { get; set; }

        [JsonPropertyName("Version")]
        public string? Version { get; set; }

        [JsonPropertyName("Source")]
        public string? Source { get; set; }

        [JsonPropertyName("DebugModeExpirationDate")]
        public DateTimeOffset? DebugModeExpirationDate { get; set; }

        [JsonPropertyName("UpdateInfo")]
        public UpdateInfo? UpdateInfo { get; set; }

        [JsonPropertyName("InstallationId")]
        public Guid? InstallationId { get; set; }

        [JsonPropertyName("Platform")]
        public string? Platform { get; set; }

        [JsonPropertyName("EndpointDetection")]
        public string? EndpointDetection { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
