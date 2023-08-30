using DataAccess.QueryModels;

namespace DataAccess.CourseAttendancesQueryRepository;

public interface ICourseAttendancesQueryRepository
{
    public Task<List<CourseAttendancesQueryModel>> GetCourseAttendances(Guid id);

}