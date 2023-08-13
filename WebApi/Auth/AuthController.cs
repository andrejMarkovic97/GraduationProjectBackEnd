using Infrastructure.AuthService;
using Infrastructure.LoginDto;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Auth
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
        // GET: api/Join
        [HttpGet("Authenticate")]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            var token = await _authService.Authenticate(user);
            
            return token == null 
                ? Unauthorized("Invalid credentials")
                : Ok(token);
        }

       
    }
}
