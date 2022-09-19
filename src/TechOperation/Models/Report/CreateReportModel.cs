using Newtonsoft.Json;

namespace TechOperation.Models.Report
{
    public class CreateReportModel
    {
        [JsonProperty("telegramId")]
        public int TelegramId { get; set; }

        [JsonProperty("latitude")]
        public float? Latitude { get; set; }

        [JsonProperty("longitude")]
        public float? Longitude { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
