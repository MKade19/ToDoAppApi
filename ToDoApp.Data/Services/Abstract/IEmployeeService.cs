using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IEmployeeService : IDataService<Employee>
    {
        Task<IEnumerable<PublicEmployee>> GetAllPublicAsync();
        Task<PublicEmployee> GetByIdPublicAsync(int id);
        Task<IEnumerable<PublicEmployee>> GetBySearchDataAsync(EmployeeSearchData searchData);

    }
}
