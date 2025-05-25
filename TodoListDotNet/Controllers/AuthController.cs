using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListDotNet.DTOs;
using TodoListDotNet.DTOs.Requests;
using TodoListDotNet.DTOs.Responses;
using TodoListDotNet.Services.Auth;

namespace TodoListDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            try
            {
                var token = await _authService.Login(request.Email, request.Password);
                return Ok(new ApiResponse<object>(new { token = token }, "Login bem-sucedido"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao logar", e.Message));
            }
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] AuthRegisterRequest request)
        {
            try
            {
                var user = await _authService.Register(request.Name, request.Email, request.Password);
                return Created("/",new ApiResponse<UserDTO>(user, "Registro cadastrado com sucesso"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao registro", e.Message));
            }
        }
    }
}
