using Newtonsoft.Json;

namespace TechOperation.Models.Event
{
    public class RequestEventsModel
    {
        [JsonProperty("roleCode")]
        public string? RoleCode { get; set; }
    }
}
