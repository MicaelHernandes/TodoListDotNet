using Microsoft.AspNetCore.Identity;
using TodoListDotNet.Infra.Repositories.User;
using TodoListDotNet.Models;

namespace TodoListDotNet.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;
    
    public AuthService(IUserRepository userRepository, TokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    
    public async Task<object> Login(string email, string password)
    {
        try
        {
            var user =await _userRepository.getUserByEmail(email);
            if (user == null)
            {
                throw new Exception("Usuario ou senha invalidos!!");
            }

            var passwordHasher = new PasswordHasher<User>();
            var result = passwordHasher.VerifyHashedPassword(user, user.Password, password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new Exception("Usuario ou senha invalidos!!");
            }
            var token = _tokenService.GenerateToken(user);
            
            return token;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Task<object> Register(string email, string password)
    {
        throw new NotImplementedException();
    }
}