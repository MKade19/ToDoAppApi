using ToDoApp.Models;

namespace ToDoApp.Services.Abstract
{
    public interface IAuthService
    {
        Task<AuthData> LoginAsync(User user);
        Task RegisterAsync(User user);
    }
}
