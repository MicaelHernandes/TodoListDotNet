using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TodoListDotNet.DTOs;
using TodoListDotNet.Infra.Repositories.User;
using TodoListDotNet.Models;

namespace TodoListDotNet.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;
    
    public AuthService(IUserRepository userRepository, TokenService tokenService , IMapper mapper)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
        _mapper = mapper;
    }
    
    public async Task<string> Login(string email, string password)
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

    public async Task<UserDTO> Register(string name, string email, string password)
    {
        try
        {
            var user = new User
            {
                Name = name,
                Mail = email,
                Password = password
            };
            
            var passwordHasher = new PasswordHasher<User>();
            user.Password = passwordHasher.HashPassword(user, password);
            var result = await _userRepository.addUser(user);
            return _mapper.Map<UserDTO>(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}