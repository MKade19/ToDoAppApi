using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IEmployeeService : IDataService<Employee>
    {
        Task<PublicEmployee> GetByFullnameAsync(string fullname);
        Task<IEnumerable<PublicEmployee>> GetAllPublicAsync();
        Task<PublicEmployee> GetByIdPublicAsync(int id);
    }
}
