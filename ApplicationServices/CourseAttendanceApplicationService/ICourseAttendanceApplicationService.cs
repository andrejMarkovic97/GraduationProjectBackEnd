using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.GenericApplicationService;
using Domain.Entities;

namespace ApplicationServices.CourseAttendanceApplicationService;

public interface ICourseAttendanceApplicationService : IGenericApplicationService<CourseAttendance, CourseAttendancePostDto>
{
    public Task<List<CourseAttendanceDto>> GetCourseAttendances(Guid id);
    public Task CreateCourseAttendances(List<CourseAttendancePostDto> attendances);

    public Task DeleteAsync(Guid courseId, Guid userId);
}