using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("objectivesPermission")]
        public string? ObjectivesPermission { get; set; }

        [JsonPropertyName("employeesPermission")]
        public string? EmployeesPermission { get; set; }

        [JsonPropertyName("specialitiesPermission")]
        public string? SpecialitiesPermission { get; set; }
    }
}
