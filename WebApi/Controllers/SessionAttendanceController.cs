using ApplicationServices.DataTransferObjects.SessionAttendance;
using ApplicationServices.SessionAttendanceApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SessionAttendanceController : ControllerBase
    {
        private readonly ISessionAttendanceApplicationService _sessionAttendanceApplicationService;

        public SessionAttendanceController(ISessionAttendanceApplicationService sessionAttendanceApplicationService)
        {
            _sessionAttendanceApplicationService = sessionAttendanceApplicationService;
        }
        [HttpGet("GetSessionAttendances/{id}")]
        public async Task<IActionResult> GetSessionAttendances(Guid id)
        {
            var list = await _sessionAttendanceApplicationService.GetSessionAttendances(id);
            return Ok(list);
        }

        [HttpPost("AddSessionAttendances")]
        public async Task<IActionResult> AddSessionAttendances(List<SessionAttendanceDto> attendances)
        {
            await _sessionAttendanceApplicationService.CreateSessionAttendances(attendances);
            return Ok();
        }
        
        [HttpDelete("{sessionId}/{userId}")]
        public async Task<IActionResult> Delete(Guid sessionId, Guid userId)
        {
            await _sessionAttendanceApplicationService.DeleteAsync(sessionId, userId);
            return Ok();
        }
    }
}
