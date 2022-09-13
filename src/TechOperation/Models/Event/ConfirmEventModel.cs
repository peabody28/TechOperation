using Newtonsoft.Json;

namespace TechOperation.Models.Event
{
    public class ConfirmEventModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
