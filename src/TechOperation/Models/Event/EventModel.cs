using Newtonsoft.Json;

namespace TechOperation.Models.Event
{
    public class EventModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("roleCode")]
        public string RoleCode { get; set; }
    }
}
