using ApplicationServices.DataTransferObjects.SessionAttendance;
using ApplicationServices.GenericApplicationService;
using Domain.Entities;

namespace ApplicationServices.SessionAttendanceApplicationService;

public interface ISessionAttendanceApplicationService : IGenericApplicationService<SessionAttendance, SessionAttendanceDto>
{
    public Task<List<SessionAttendanceDto>> GetSessionAttendances(Guid sessionId);

    public Task DeleteAsync(Guid sessionId, Guid userId);

    public Task CreateSessionAttendances(List<SessionAttendanceDto> sessionAttendances);
}