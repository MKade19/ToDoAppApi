using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    [Table("Employees")]
    public class Employee
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

        [JsonPropertyName("roleId")]
        public int RoleId { get; set; } = 1;

        [ForeignKey(nameof(RoleId))]
        public Role? Role { get; set; }

        [JsonPropertyName("specialityId")]
        public int SpecialityId { get; set; }

        [ForeignKey(nameof(SpecialityId))]
        public Speciality? Speciality { get; set; }

        [JsonPropertyName("password")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public byte[]? Salt { get; set; }

        [JsonConstructor]
        public Employee(int id, string username, string fullname, DateTime employmentDate, int age, int roleId, int specialityId)
        {
            Id = id;
            Username = username;
            Fullname = fullname;
            EmploymentDate = employmentDate;
            Age = age;
            RoleId = roleId;
            SpecialityId = specialityId;
        }

        public Employee(Employee employee)
        {
            Id = employee.Id;
            Username = employee.Username;
            Fullname = employee.Fullname;
            EmploymentDate = employee.EmploymentDate;
            Age = employee.Age;
            RoleId = employee.RoleId;
            SpecialityId = employee.SpecialityId;
        }

        public Employee() { }
    }
}
