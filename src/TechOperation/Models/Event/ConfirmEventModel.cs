using Newtonsoft.Json;

namespace TechOperation.Models.Event
{
    public class ConfirmEventModel
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
