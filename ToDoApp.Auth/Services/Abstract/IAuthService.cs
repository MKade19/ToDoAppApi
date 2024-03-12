using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthData> LoginAsync(LoginUser user);
        Task RegisterAsync(DbEmployee user);
    }
}
