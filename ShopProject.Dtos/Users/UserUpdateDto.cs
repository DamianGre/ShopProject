using Newtonsoft.Json;

namespace ShopProject.Dtos.Users
{
    public class UserUpdateDto
    {
        [JsonProperty(Required = Required.AllowNull)]
        public string Name { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public string Password { get; set; }

        [JsonProperty(Required = Required.AllowNull)]
        public string Email { get; set; }
    }
}
