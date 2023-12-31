using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.GenericApplicationService;
using Domain.Entities;

namespace ApplicationServices.CourseApplicationService;

public interface ICourseApplicationService : IGenericApplicationService<Course, CourseReadDto>
{
    public Task<CourseCreateUpdateGetDto> CreateAsync(CourseCreateUpdateDto dto);
    
    public new Task<CourseCreateUpdateGetDto> GetByIdAsync(Guid id);

    public Task<CourseCreateUpdateGetDto> UpdateAsync(CourseCreateUpdateDto dto);
    
    public Task<List<UserDto>> GetUsersNotAttendingCourse(Guid id);
    
}