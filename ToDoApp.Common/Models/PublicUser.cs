using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class PublicUser
    {
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [JsonConstructor]
        public PublicUser(int id, string username)
        {
            Id = id;
            Username = username;
        }
    }
}
