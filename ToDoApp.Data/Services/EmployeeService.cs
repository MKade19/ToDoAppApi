using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task CreateOneAsync(PublicEmployee employee)
        {
            await _employeeRepository.CreateOneAsync(employee);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _employeeRepository.DeleteByIdAsync(id);
        }

        public async Task<IEnumerable<PublicEmployee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<PublicEmployee> GetByFullnameAsync(string username)
        {
            return await _employeeRepository.GetByFullnameAsync(username);
        }

        public async Task UpdateByIdAsync(PublicEmployee employee)
        {
            await _employeeRepository.UpdateByIdAsync(employee);
        }
    }
}
