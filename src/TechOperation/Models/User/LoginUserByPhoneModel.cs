using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class LoginUserByPhoneModel
    {
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
