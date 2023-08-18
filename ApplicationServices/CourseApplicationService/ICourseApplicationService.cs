using ApplicationServices.DataTransferObjects.Course;

namespace ApplicationServices.CourseApplicationService;

public interface ICourseApplicationService
{
    public Task<CourseReadDto> CreateAsync(CourseCreateUpdateDto dto);
}