using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
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
