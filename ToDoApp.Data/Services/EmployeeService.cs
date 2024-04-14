﻿using ToDoApp.Common.Models;
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

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee> GetByFullnameAsync(string username)
        {
            return await _employeeRepository.GetByFullnameAsync(username);
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateByIdAsync(Employee employee)
        {
            await _employeeRepository.UpdateByIdAsync(employee);
        }
    }
}
