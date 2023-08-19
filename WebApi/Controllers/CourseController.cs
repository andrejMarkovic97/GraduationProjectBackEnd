using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.CourseApplicationService;
using ApplicationServices.DataTransferObjects.Course;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProjectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
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

        [Authorize]
        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var course =  await _courseApplicationService.GetByIdAsync(id);

            return Ok(course);
        }

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> Post(CourseCreateUpdatePostDto dto)
        {
            var course = await _courseApplicationService.CreateAsync(dto);

            return Ok(course);
        }

        // PUT: api/Course
        [HttpPut]
        public async Task<IActionResult> Put(CourseCreateUpdatePostDto dto)
        {
            var course = await _courseApplicationService.UpdateAsync(dto);

            return Ok(course);
        }

        // DELETE: api/Course/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
