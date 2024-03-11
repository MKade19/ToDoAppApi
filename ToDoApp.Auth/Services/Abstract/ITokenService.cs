namespace ToDoApp.Auth.Services.Abstract
{
    public interface ITokenService
    {
        string GetToken(object payload);
    }
}
