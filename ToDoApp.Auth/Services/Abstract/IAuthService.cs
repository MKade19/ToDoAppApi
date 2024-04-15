using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthData> LoginAsync(LoginData user);
        Task RegisterAsync(Employee user);
        Task ChangePasswordAsync(ChangePasswordData changePasswordData);
    }
}
