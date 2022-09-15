using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class RequestUsersModel
    {
        [JsonProperty("roleCode")]
        public string? RoleCode { get; set; }
    }
}
