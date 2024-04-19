using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Common.Models
{
    public class ObjectiveSearchData
    {
        public string? Title { get; set; } = string.Empty;

        public bool? Completion { get; set; } = null;

        public DateTime? MinDate { get; set; } = null;
         
        public DateTime? MaxDate { get; set; } = null;

        [Required]
        public int EmployeeId { get; set; }
    }
}
