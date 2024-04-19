using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<PublicEmployee> GetByUsernameAsync(string username);
        Task<IEnumerable<PublicEmployee>> GetAllPublicAsync();
        Task<PublicEmployee> GetByIdPublicAsync(int id);
    }
}
