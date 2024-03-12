using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Auth.Services.Abstract;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Controllers
{
    [ApiController]
    [Route("api/to-do-app/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthData> LoginAsync([FromBody] LoginUser user)
        {
            return await _authService.LoginAsync(user); 
        }

        [HttpPost("register")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> RegisterAsync([FromBody] DbEmployee user)
        {
            return StatusCode(StatusCodes.Status201Created);
            await _authService.RegisterAsync(user);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
