using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IObjectiveRepository : IRepository<Objective>
    {
        Task<Objective> GetByTitleAsync(string title);
        Task<IEnumerable<Objective>> GetByEmployeeIdAsync(int employeeId);
    }
}
