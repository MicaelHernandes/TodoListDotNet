using TodoListDotNet.DTOs;
using TodoListDotNet.Models;

namespace TodoListDotNet.Services.Auth;

public interface IAuthService
{
    Task<string> Login(string email, string password);
    Task<UserDTO> Register(string name, string email, string password);
}