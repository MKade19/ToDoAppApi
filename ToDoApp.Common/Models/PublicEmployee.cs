using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class PublicEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("fullname")]
        [StringLength(50)]
        public string Fullname { get; set; } = string.Empty;

        [JsonPropertyName("employmentDate")]
        public DateTime EmploymentDate { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("role")]
        public Role? Role { get; set; }

        [JsonPropertyName("speciality")]
        public Speciality? Speciality { get; set; }

        [JsonPropertyName("image-name")]
        public string? ImageName { get; set; }
    }
}
