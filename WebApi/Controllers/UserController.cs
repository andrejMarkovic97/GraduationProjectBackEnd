using Application.DataTransferObjects;
using Application.GenericService;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericService<UserDto,User> _userService;

        public UserController(IGenericService<UserDto,User> userService)
        {
            _userService = userService;
        }
       // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _userService.GetAllAsync();
            return Ok(data);
        }

       // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
