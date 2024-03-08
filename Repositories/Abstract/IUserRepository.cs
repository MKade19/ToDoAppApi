using ToDoApp.Models;

namespace ToDoApp.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsername(string username);
    }
}
