using ApplicationServices.DataTransferObjects.Session;
using ApplicationServices.SessionApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SessionController : ControllerBase
    {
        private readonly ISessionApplicationService _sessionApplicationService;

        public SessionController(ISessionApplicationService sessionApplicationService)
        {
            _sessionApplicationService = sessionApplicationService;
        }
        // // GET: api/Session
        // [HttpGet]
        // public async Task<IActionResult>Get()
        // {
        //     
        // }

        // GET: api/Session/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var session = await _sessionApplicationService.GetByIdAsync(id);

            return session != null 
                ? Ok(session)
                : NotFound();
        }

        [HttpGet("GetCourseSessions/{id}")]
        public async Task<IActionResult> GetCourseSessions(Guid id)
        {
            var list = await _sessionApplicationService.GetCourseSessions(id);
            return Ok(list);
        }

        // POST: api/Session
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SessionDto dto)
        {
            var session = await _sessionApplicationService.CreateAsync(dto);
            return Ok(session);
        }

        // PUT: api/Session/5
        [HttpPut]
        public async Task<IActionResult> Put(SessionDto dto)
        {
          var session =  await _sessionApplicationService.UpdateAsync(dto);
            
            return Ok(session);
        }

        // DELETE: api/Session/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _sessionApplicationService.DeleteAsync(id);
        }

        [HttpGet("GetSessionAttendances/{id}")]
        public async Task<IActionResult> GetSessionAttendances(Guid id)
        {
            var list = await _sessionApplicationService.GetCourseSessions(id);
            return Ok(list);
        }
        
        [HttpGet("GetUsersNotAttendingSession/{id}")]
        public async Task<IActionResult> GetUsersNotAttendingSession(Guid id)
        {
            var list = await _sessionApplicationService.GetUsersNotAttendingSession(id);

            return Ok(list);
        }

    }
}