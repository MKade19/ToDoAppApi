using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    [Table("Employees")]
    public class PublicEmployee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fullname")]
        [Column("Fullname")]
        [StringLength(50)]
        public string Fullname { get; set; } = string.Empty;

        [JsonPropertyName("employmentDate")]
        public DateTime EmploymentDate { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; } = 1;

        [JsonPropertyName("specialityId")]
        public int SpecialityId { get; set; }

        [JsonConstructor]
        public PublicEmployee(int id, string username, DateTime employmentDate, int age, int roleId, int specialityId)
        {
            Id = id;
            Fullname = username;
            EmploymentDate = employmentDate;
            Age = age;
            RoleId = roleId;
            SpecialityId = specialityId;
        }

        public PublicEmployee() { }
    }
}
