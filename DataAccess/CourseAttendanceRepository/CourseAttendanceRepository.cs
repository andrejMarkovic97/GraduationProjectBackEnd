using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.CourseAttendanceRepository;

public class CourseAttendanceRepository : GenericRepository<CourseAttendance>, ICourseAttendanceRepository
{
    public CourseAttendanceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task DeleteAsync(Guid courseId, Guid userId)
    {
       var courseAttendance = await DbContext.CourseAttendances.FindAsync(courseId, userId);
       if (courseAttendance != null)
       {
           DbContext.CourseAttendances.Remove(courseAttendance);
           await DbContext.SaveChangesAsync();
       }
    }
}