namespace ToDoApp.Common.Models
{
    public class EmployeeSearchData
    {
        public string? Username { get; set; } = string.Empty;

        public string? Fullname { get; set; } = string.Empty;

        public DateTime? MinDate { get; set; } = null;

        public DateTime? MaxDate { get; set; } = null;

        public int? MinAge { get; set; }

        public int? MaxAge { get; set; }

        public int? RoleId { get; set; }

        public int? SpecialityId { get; set; }
    }
}
