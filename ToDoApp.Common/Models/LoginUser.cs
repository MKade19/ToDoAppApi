using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class LoginUser
    {
        [JsonPropertyName("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [JsonConstructor]
        public LoginUser(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
