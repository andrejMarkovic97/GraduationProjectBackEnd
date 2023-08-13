using Infrastructure.AuthModels;
using Infrastructure.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Auth
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDto user)
        {
            var token = await _authService.Authenticate(user);
            
            return token == null 
                ? Unauthorized("Invalid credentials")
                : Ok(token);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto user)
        {
            var result = await _authService.Register(user);

            return Ok(result);
        }
       
    }
}
