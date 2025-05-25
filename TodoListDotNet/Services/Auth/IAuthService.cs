namespace TodoListDotNet.Services.Auth;

public interface IAuthService
{
    Task<object> Login(string email, string password);
    Task<object> Register(string email, string password);
}