using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class EmployeeUIData
    {
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [JsonPropertyName("role")]
        [Required]
        public Role Role{ get; set; }

        [JsonConstructor]
        public EmployeeUIData(int id, string username, Role role)
        {
            Id = id;
            Username = username;
            Role = role;
        }
    }
}
