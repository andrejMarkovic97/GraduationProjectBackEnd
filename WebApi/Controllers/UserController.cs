using System.Security.Claims;
using ApplicationServices.DataTransferObjects;
using ApplicationServices.GenericApplicationService;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericApplicationService<User, UserDto> _userApplicationService;


        public UserController(IGenericApplicationService<User,UserDto> userApplicationService)
        {
            _userApplicationService = userApplicationService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _userApplicationService.GetAllAsync();
            return Ok(data);
        }

       // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpGet("GetActiveUser")]
        [Authorize]
        public async Task<IActionResult?> GetActiveUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId != null
                ? Ok(await _userApplicationService.GetByIdAsync(Guid.Parse(userId)))
                : null;
        }
        
        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        
        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
