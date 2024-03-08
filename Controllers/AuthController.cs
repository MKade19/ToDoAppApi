using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;
using ToDoApp.Services.Abstract;

namespace ToDoApp.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<AuthData> LoginAsync([FromBody] User user)
        {
            return await _authService.LoginAsync(user); 
        }

        [HttpPost("register")]
        public async Task RegisterAsync([FromBody] User user)
        {
            await _authService.RegisterAsync(user);
        }
    }
}
