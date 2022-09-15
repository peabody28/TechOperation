using Newtonsoft.Json;

namespace TechOperation.Models.Report
{
    public class CreateLocationReportModel
    {
        [JsonProperty("telegramId")]
        public int TelegramId { get; set; }

        [JsonProperty("latitude")]
        public float Latitude { get; set; }

        [JsonProperty("longitude")]
        public float Longitude { get; set; }
    }
}
