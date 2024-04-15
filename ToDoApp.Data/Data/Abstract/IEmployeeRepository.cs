using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<PublicEmployee> GetByFullnameAsync(string name);
        Task<IEnumerable<PublicEmployee>> GetAllPublicAsync();
        Task<PublicEmployee> GetByIdPublicAsync(int id);
    }
}
