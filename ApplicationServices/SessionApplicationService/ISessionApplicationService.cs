using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Session;
using ApplicationServices.GenericApplicationService;
using Domain.Entities;

namespace ApplicationServices.SessionApplicationService;

public interface ISessionApplicationService : IGenericApplicationService<Session, SessionDto>
{
    Task<List<SessionDto>> GetCourseSessions(Guid id);

    public Task<List<UserDto>> GetUsersNotAttendingSession(Guid id);

}