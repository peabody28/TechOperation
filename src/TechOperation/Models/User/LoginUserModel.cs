using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class LoginUserModel
    {
        [JsonProperty("telegramId")]
        public int TelegramId { get; set; }
    }
}
