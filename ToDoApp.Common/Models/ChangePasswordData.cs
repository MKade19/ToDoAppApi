using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class ChangePasswordData
    {
        [JsonPropertyName("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("oldPassword")]
        [Required]
        [StringLength(255)]
        public string OldPassword { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [Required]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public byte[]? Salt { get; set; }
    }
}
