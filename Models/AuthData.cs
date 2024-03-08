using System.Text.Json.Serialization;

namespace ToDoApp.Models
{
    public class AuthData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonConstructor]
        public AuthData(string token)
        {
            Token = token;
        }
    }
}
