using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IEmployeeService
    {
        Task CreateOneAsync(PublicEmployee employee);

        Task DeleteByIdAsync(int id);

        Task<IEnumerable<PublicEmployee>> GetAllAsync();
        Task<PublicEmployee> GetByFullnameAsync(string fullname);

        Task UpdateByIdAsync(PublicEmployee employee);
    }
}
