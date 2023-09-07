using DataAccess.DbContext;
using DataAccess.GenericRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SessionAttendanceRepository;

public class SessionAttendanceRepository : GenericRepository<SessionAttendance>, ISessionAttendanceRepository
{
    public SessionAttendanceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<SessionAttendance>> GetSessionAttendances(Guid sessionId)
    {
        return await DbContext.SessionAttendances
            .Where(sa => sa.SessionId == sessionId)
            .Include(sa => sa.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid sessionId, Guid userId)
    {
        var sessionAttendance = await DbContext.SessionAttendances.FindAsync(sessionId, userId);

        if (sessionAttendance != null)
        {
            DbContext.SessionAttendances.Remove(sessionAttendance);
            await DbContext.SaveChangesAsync();
        }
    }

    public async Task DeleteSessionAttendancesByCourseId(Guid courseId, Guid userId)
    {
        var attendancesToBeDeleted = await DbContext.SessionAttendances
            .Include(sa => sa.Session)
            .Where(sa => sa.Session.CourseId == courseId && sa.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
        
        DbContext.SessionAttendances.RemoveRange(attendancesToBeDeleted);
        await DbContext.SaveChangesAsync();
    }
}