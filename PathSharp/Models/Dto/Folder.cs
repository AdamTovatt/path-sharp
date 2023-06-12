using PathSharp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PathSharp.Models.Dto
{
    public class Folder
    {
        [JsonPropertyName("Key")]
        public Guid Key { get; set; }

        [JsonPropertyName("DisplayName")]
        public string? DisplayName { get; set; }

        [JsonPropertyName("FullyQualifiedName")]
        public string? FullyQualifiedName { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("FolderType")]
        public string? FolderType { get; set; }

        [JsonPropertyName("IsPersonal")]
        public bool IsPersonal { get; set; }

        [JsonPropertyName("ProvisionType")]
        public string? ProvisionType { get; set; }

        [JsonPropertyName("PermissionModel")]
        public string? PermissionModel { get; set; }

        [JsonPropertyName("ParentId")]
        public long? ParentId { get; set; }

        [JsonPropertyName("ParentKey")]
        public Guid? ParentKey { get; set; }

        [JsonPropertyName("FeedType")]
        public string? FeedType { get; set; }

        [JsonPropertyName("Id")]
        public long Id { get; set; }

        public static List<Folder>? GetListFromJson(string json)
        {
            return JsonSerializer.Deserialize<List<Folder>>(json.GetJsonProperty("value"));
        }
    }
}
