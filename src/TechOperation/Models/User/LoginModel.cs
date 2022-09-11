using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class LoginModel
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
