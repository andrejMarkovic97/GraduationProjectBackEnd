using ApplicationServices.DataTransferObjects.Course;

namespace ApplicationServices.CourseApplicationService;

public interface ICourseApplicationService
{
    public Task<CourseCreateUpdateGetDto> CreateAsync(CourseCreateUpdatePostDto dto);

    public Task<List<CourseReadDto>> GetAllAsync();

    public Task<CourseCreateUpdateGetDto> GetByIdAsync(Guid id);

    public Task<CourseCreateUpdateGetDto> UpdateAsync(CourseCreateUpdatePostDto dto);

}