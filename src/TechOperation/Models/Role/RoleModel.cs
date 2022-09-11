using Newtonsoft.Json;

namespace TechOperation.Models.Role
{
    public class RoleModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
