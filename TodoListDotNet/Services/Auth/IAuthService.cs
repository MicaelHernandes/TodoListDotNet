using TodoListDotNet.DTOs;

namespace TodoListDotNet.Services.Auth;

public interface IAuthService
{
    Task<object> Login(string email, string password);
    Task<UserDTO> Register(string name, string email, string password);
}