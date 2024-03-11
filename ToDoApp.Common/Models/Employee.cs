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
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("username")]
        [Column("Fullname")]
        [StringLength(50)]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("password")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public byte[]? Salt { get; set; }

        [JsonPropertyName("employmentDate")]
        public DateTime EmploymentDate { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
        public int RoleId { get; set; } = 1;

        [JsonPropertyName("specialityId")]
        public int SpecialityId { get; set; }

        public Role? Role { get; set; }

        [JsonConstructor]
        public Employee(string username, string password, int age, int specialityId, DateTime employmentDate)
        {
            Username = username;
            Password = password;
            EmploymentDate = employmentDate;
            Age = age;
            SpecialityId = specialityId;
        }

        public Employee(int id, string username, string password, byte[]? salt, int roleId)
        {
            Id = id;
            Username = username;
            Password = password;
            Salt = salt;
            RoleId = roleId;
        }

        public Employee() { }
    }
}
