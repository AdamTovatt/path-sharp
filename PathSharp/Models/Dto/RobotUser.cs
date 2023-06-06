using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class RobotUser
    {
        [JsonPropertyName("UserName")]
        public string? UserName { get; set; }

        [JsonPropertyName("RobotId")]
        public long RobotId { get; set; }

        [JsonPropertyName("HasTriggers")]
        public bool HasTriggers { get; set; }
    }
}
