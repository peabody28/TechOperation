using Newtonsoft.Json;

namespace TechOperations.Models.User
{
    public class LoginModel
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
