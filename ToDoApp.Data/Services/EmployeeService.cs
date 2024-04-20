using ToDoApp.Common.Models;
using ToDoApp.Data.Data.Abstract;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHashService _hashService;

        public EmployeeService(IEmployeeRepository employeeRepository, IHashService hashService)
        {
            _employeeRepository = employeeRepository;
            _hashService = hashService;
        }

        public async Task CreateOneAsync(Employee employee)
        {
            employee.Password = _hashService.GetHash(employee.Password, out byte[] salt);
            employee.Salt = salt;

            await _employeeRepository.CreateOneAsync(employee);
        }

        public async Task DeleteByIdAsync(int id)
        {
            await _employeeRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PublicEmployee>> GetAllPublicAsync()
        {
            return await _employeeRepository.GetAllPublicAsync();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PublicEmployee> GetByIdPublicAsync(int id)
        {
            return await _employeeRepository.GetByIdPublicAsync(id);
        }

        public async Task<IEnumerable<PublicEmployee>> GetBySearchDataAsync(EmployeeSearchData searchData)
        {
            return await _employeeRepository.GetBySearchDataAsync(searchData);
        }

        public async Task UpdateByIdAsync(Employee employee)
        {
            if (!string.IsNullOrEmpty(employee.Password))
            {
                employee.Password = _hashService.GetHash(employee.Password, out byte[] salt);
                employee.Salt = salt;
            }

            await _employeeRepository.UpdateByIdAsync(employee);
        }
    }
}
