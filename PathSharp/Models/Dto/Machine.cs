using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Machine
    {
        [JsonPropertyName("LicenseKey")]
        public string? LicenseKey { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Scope")]
        public string? Scope { get; set; }

        [JsonPropertyName("NonProductionSlots")]
        public long NonProductionSlots { get; set; }

        [JsonPropertyName("UnattendedSlots")]
        public long UnattendedSlots { get; set; }

        [JsonPropertyName("HeadlessSlots")]
        public long HeadlessSlots { get; set; }

        [JsonPropertyName("TestAutomationSlots")]
        public long TestAutomationSlots { get; set; }

        [JsonPropertyName("AutomationCloudSlots")]
        public long AutomationCloudSlots { get; set; }

        [JsonPropertyName("AutomationCloudTestAutomationSlots")]
        public long AutomationCloudTestAutomationSlots { get; set; }

        [JsonPropertyName("Key")]
        public Guid Key { get; set; }

        [JsonPropertyName("EndpointDetectionStatus")]
        public string? EndpointDetectionStatus { get; set; }

        [JsonPropertyName("RobotVersions")]
        public List<RobotVersion>? RobotVersions { get; set; }

        [JsonPropertyName("RobotUsers")]
        public List<RobotUser>? RobotUsers { get; set; }

        [JsonPropertyName("AutomationType")]
        public string? AutomationType { get; set; }

        [JsonPropertyName("TargetFramework")]
        public string? TargetFramework { get; set; }

        [JsonPropertyName("UpdatePolicy")]
        public UpdatePolicy? UpdatePolicy { get; set; }

        [JsonPropertyName("ClientSecret")]
        public string? ClientSecret { get; set; }

        [JsonPropertyName("Tags")]
        public List<Tag>? Tags { get; set; }

        [JsonPropertyName("MaintenanceWindow")]
        public MaintenanceWindow? MaintenanceWindow { get; set; }

        [JsonPropertyName("VpnSettings")]
        public VpnSettings? VpnSettings { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }
    }
}
