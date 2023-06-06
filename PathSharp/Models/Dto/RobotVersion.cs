using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class RobotVersion
    {
        [JsonPropertyName("Count")]
        public long Count { get; set; }

        [JsonPropertyName("Version")]
        public string? Version { get; set; }

        [JsonPropertyName("MachineId")]
        public long MachineId { get; set; }
    }
}
