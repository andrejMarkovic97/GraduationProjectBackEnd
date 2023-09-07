using DataAccess.GenericRepository;
using Domain.Entities;

namespace DataAccess.SessionAttendanceRepository;

public interface ISessionAttendanceRepository : IGenericRepository<SessionAttendance>
{
    public Task<List<SessionAttendance>> GetSessionAttendances(Guid sessionId);

    public Task DeleteAsync(Guid sessionId, Guid userId);

    public Task DeleteSessionAttendancesByCourseId(Guid courseId, Guid userId);
}