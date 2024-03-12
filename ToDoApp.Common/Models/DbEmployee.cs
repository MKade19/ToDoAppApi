using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    [Table("Employees")]
    public class DbEmployee : Employee
    {
        [JsonPropertyName("password")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        public byte[]? Salt { get; set; }

        public Role? Role { get; set; }

        [JsonConstructor]
        public DbEmployee(int id, string fullname, string password, int age, int roleId, int specialityId, DateTime employmentDate) 
            : base(id, fullname, employmentDate, age, roleId, specialityId)
        {
            Password = password;
        }

        public DbEmployee() { }
    }
}
