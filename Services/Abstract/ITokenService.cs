namespace ToDoApp.Services.Abstract
{
    public interface ITokenService
    {
        string GetToken(object payload);
    }
}
