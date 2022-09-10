using Newtonsoft.Json;

namespace TechOperations.Models.Role
{
    public class RoleModel
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
