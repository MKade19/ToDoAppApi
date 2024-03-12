using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("fullname")]
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
        public Employee(int id, string fullname, DateTime employmentDate, int age, int roleId, int specialityId)
        {
            Id = id;
            Fullname = fullname;
            EmploymentDate = employmentDate;
            Age = age;
            RoleId = roleId;
            SpecialityId = specialityId;
        }

        public Employee() { }
    }
}
