using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Data.Abstract
{
    public interface IUserRepository
    {
        Task CreateOneAsync(Employee user);
        Task<Employee?> GetByUsername(string username);
    }
}
