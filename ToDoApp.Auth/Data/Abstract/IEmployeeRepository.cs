using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data.Abstract
{
    public interface IEmployeeRepository
    {
        Task CreateOneAsync(Employee employee);
        Task<Employee?> GetByUsername(string username);
    }
}
