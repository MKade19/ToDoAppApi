using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Common.Models;
using ToDoApp.Data.Services.Abstract;

namespace ToDoApp.Data.Controllers
{
    [ApiController]
    [Route("api/to-do-app/roles")]
    public class RoleController
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _roleService.GetAllAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<Role> GetByFullnameAsync(int id)
        {
            return await _roleService.GetByIdAsync(id);
        }
    }
}
