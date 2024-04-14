using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class AuthData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("user")]
        public PublicEmployee User { get; set; }

        [JsonConstructor]
        public AuthData(string token, PublicEmployee user)
        {
            Token = token;
            User = user;
        }
    }
}
