using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Models;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Controllers
{
    [ApiController]
    [Route("api/to-do-app/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _employeeService.GetAllAsync(); 
        }

        [HttpGet("{fullname}")]
        [Authorize(Roles = "Admin")]
        public async Task<Employee> GetByFullnameAsync(string fullname)
        {
            return await _employeeService.GetByFullnameAsync(fullname);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateOneAsync([FromBody] DbEmployee employee) 
        {
            await _employeeService.CreateOneAsync(employee);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task UpdateByIdAsync([FromBody] Employee employee)
        {
            await _employeeService.UpdateByIdAsync(employee);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task DeleteByIdAsync(int id)
        {
            await _employeeService.DeleteByIdAsync(id);
        }
    }
}
