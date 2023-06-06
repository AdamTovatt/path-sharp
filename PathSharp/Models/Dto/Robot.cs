using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Robot
    {
        [JsonPropertyName("LicenseKey")]
        public string? LicenseKey { get; set; }

        [JsonPropertyName("MachineName")]
        public string? MachineName { get; set; }

        [JsonPropertyName("MachineId")]
        public long MachineId { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Username")]
        public string? Username { get; set; }

        [JsonPropertyName("ExternalName")]
        public string? ExternalName { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("HostingType")]
        public string? HostingType { get; set; }

        [JsonPropertyName("ProvisionType")]
        public string? ProvisionType { get; set; }

        [JsonPropertyName("Password")]
        public string? Password { get; set; }

        [JsonPropertyName("CredentialStoreId")]
        public long CredentialStoreId { get; set; }

        [JsonPropertyName("UserId")]
        public long UserId { get; set; }

        [JsonPropertyName("Enabled")]
        public bool Enabled { get; set; }

        [JsonPropertyName("CredentialType")]
        public string? CredentialType { get; set; }

        [JsonPropertyName("Environments")]
        public List<Environment>? Environments { get; set; }

        [JsonPropertyName("RobotEnvironments")]
        public string? RobotEnvironments { get; set; }

        [JsonPropertyName("ExecutionSettings")]
        public ExecutionSettings? ExecutionSettings { get; set; }

        [JsonPropertyName("IsExternalLicensed")]
        public bool IsExternalLicensed { get; set; }

        [JsonPropertyName("LimitConcurrentExecution")]
        public bool LimitConcurrentExecution { get; set; }

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
