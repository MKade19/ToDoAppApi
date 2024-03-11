using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IEmployeeRepository : IRepository<PublicEmployee>
    {
        Task<PublicEmployee> GetByFullnameAsync(string name);
    }
}
