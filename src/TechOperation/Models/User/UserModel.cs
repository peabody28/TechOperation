﻿using Newtonsoft.Json;

namespace TechOperation.Models.User
{
    public class UserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roleCode")]
        public string RoleCode { get; set; }

        [JsonProperty("telegramId")]
        public int TelegramId { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
