using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.CourseAttendanceApplicationService;
using ApplicationServices.DataTransferObjects.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAttendanceController : ControllerBase
    {
        private readonly ICourseAttendanceApplicationService _courseAttendanceApplicationService;

        public CourseAttendanceController(ICourseAttendanceApplicationService courseAttendanceApplicationService)
        {
            _courseAttendanceApplicationService = courseAttendanceApplicationService;
        }
        [HttpGet("GetCourseAttendances/{id}")]
        public async Task<IActionResult> GetCourseAttendances(Guid id)
        {
            var list = await _courseAttendanceApplicationService.GetCourseAttendances(id);
            return Ok(list);
        }

        [HttpPost("AddCourseAttendances")]
        public async Task<IActionResult> AddCourseAttendances(List<CourseAttendancePostDto> attendances)
        {
            await _courseAttendanceApplicationService.CreateCourseAttendances(attendances);
            return Ok();
        }
        
        [HttpDelete("{courseId}/{userId}")]
        public async Task<IActionResult> Delete(Guid courseId, Guid userId)
        {
            await _courseAttendanceApplicationService.DeleteAsync(courseId, userId);
            return Ok();
        }
    }
}
