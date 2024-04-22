using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using ToDoApp.Common.Models;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Controllers
{
    [ApiController]
    [Route("api/to-do-app/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITokenService _tokenService;

        public EmployeeController(IEmployeeService employeeService, ITokenService tokenService)
        {
            _employeeService = employeeService;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<PublicEmployee>> GetAllAsync()
        {
            return await _employeeService.GetAllPublicAsync(); 
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<PublicEmployee> GetByIdAsync(int id)
        {
            return await _employeeService.GetByIdPublicAsync(id);
        }

        [HttpGet("search")]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<PublicEmployee>> GetBySearchDataAsync([FromQuery] EmployeeSearchData searchData)
        {
            return await _employeeService.GetBySearchDataAsync(searchData);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateOneAsync([FromBody] Employee employee) 
        {
            await _employeeService.CreateOneAsync(employee);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("image-upload")]
        [Authorize]
        public async Task<ActionResult> UploadImage([FromForm] IFormFile file, [FromHeader] string authorization)
        {
            string token = string.Empty;

            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                token = headerValue.Parameter ?? string.Empty;
            }

            JwtSecurityToken jwt = await _tokenService.DecodeTokenAsync(token);
            int employeeId = await _tokenService.ExtractIdFromTokenAsync(jwt);

            await _employeeService.UpdateImageAsync(file, employeeId);

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
