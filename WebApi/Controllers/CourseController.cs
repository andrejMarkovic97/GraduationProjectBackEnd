using ApplicationServices.CourseApplicationService;
using ApplicationServices.DataTransferObjects.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseApplicationService _courseApplicationService;

        public CourseController(ICourseApplicationService courseApplicationService)
        {
            _courseApplicationService = courseApplicationService;
        }
        // GET: api/Course
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        { 
            var list = await _courseApplicationService.GetAllAsync();

            return Ok(list);
        }

        // [Authorize]
        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var course =  await _courseApplicationService.GetByIdAsync(id);

            return Ok(course);
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CourseCreateUpdatePostDto dto)
        {
            var course = await _courseApplicationService.CreateAsync(dto);

            return Ok(course);
        }

        // PUT: api/Course
        [HttpPut]
        public async Task<IActionResult> Put([FromForm]CourseCreateUpdatePostDto dto)
        {
            var course = await _courseApplicationService.UpdateAsync(dto);

            return Ok(course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _courseApplicationService.DeleteAsync(id);
            return Ok();
        }
        
        
        [HttpGet("GetUsersNotAttendingCourse/{id}")]
        public async Task<IActionResult> GetUsersNotAttendingCourse(Guid id)
        {
            var list = await _courseApplicationService.GetUsersNotAttendingCourse(id);

            return Ok(list);
        }
        
    }
}
