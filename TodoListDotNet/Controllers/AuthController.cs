using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListDotNet.DTOs.Requests;
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
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
