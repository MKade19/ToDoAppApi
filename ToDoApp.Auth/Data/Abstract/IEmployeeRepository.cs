using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data.Abstract
{
    public interface IEmployeeRepository
    {
        Task CreateOneAsync(DbEmployee user);
        Task<DbEmployee?> GetByUsername(string username);
    }
}
