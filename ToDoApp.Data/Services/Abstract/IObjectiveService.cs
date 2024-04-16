using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IObjectiveService : IDataService<Objective>
    {
        Task<Objective> GetByTitleAsync(string title);
        Task<IEnumerable<Objective>> GetByEmployeeIdAsync(int employeeId);
    }
}
