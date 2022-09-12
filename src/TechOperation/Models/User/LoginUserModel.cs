using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class LoginUserModel
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
