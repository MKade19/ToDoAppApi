using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Task<Employee> GetByFullnameAsync(string name);
    }
}
