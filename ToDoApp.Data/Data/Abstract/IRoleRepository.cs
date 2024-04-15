using ToDoApp.Common.Models;

namespace ToDoApp.Data.Data.Abstract
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
    }
}
