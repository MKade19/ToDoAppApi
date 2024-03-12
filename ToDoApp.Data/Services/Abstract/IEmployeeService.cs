using ToDoApp.Common.Models;

namespace ToDoApp.Data.Services.Abstract
{
    public interface IEmployeeService : IDataService<Employee>
    {
        Task<Employee> GetByFullnameAsync(string fullname);
    }
}
