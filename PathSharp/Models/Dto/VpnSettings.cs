using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class VpnSettings
    {
        [JsonPropertyName("cidr")]
        public string? Cidr { get; set; }
    }
}
