using Newtonsoft.Json;

namespace TechOperation.Models.Event
{
    public class EventModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("roleCode")]
        public string RoleCode { get; set; }

        [JsonProperty("isConfirmed")]
        public bool IsConfirmed { get; set; }
    }
}
