using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role> GetByIdAsync(int id);
    }
}
