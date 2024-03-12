using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ToDoApp.Common.Models
{
    public class Objective
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("desciption")]
        public string Desciption { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonPropertyName("updatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeId { get; set; }

        [JsonConstructor]
        public Objective(int id, string title, string desciption, DateTime? createdDate, DateTime? updatedDate, int employeeId)
        {
            Id = id;
            Title = title;
            Desciption = desciption;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            EmployeeId = employeeId;
        }

        public Objective()
        {
        }
    }
}
