using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.CourseAttendanceRepository;

public interface ICourseAttendanceRepository : IGenericRepository<CourseAttendance>
{
    public Task DeleteAsync(Guid courseId, Guid userId);
}