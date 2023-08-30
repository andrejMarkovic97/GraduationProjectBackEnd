using ApplicationServices.DataTransferObjects.SessionAttendance;
using ApplicationServices.GenericApplicationService;
using AutoMapper;
using DataAccess.GenericRepository;
using DataAccess.SessionAttendanceRepository;
using Domain.Entities;

namespace ApplicationServices.SessionAttendanceApplicationService;

public class SessionAttendanceApplicationService : GenericApplicationService<SessionAttendance, SessionAttendanceDto>, ISessionAttendanceApplicationService
{
    private readonly ISessionAttendanceRepository _sessionAttendanceRepository;

    public SessionAttendanceApplicationService(IGenericRepository<SessionAttendance> genericRepository, IMapper mapper, ISessionAttendanceRepository sessionAttendanceRepository) 
        : base(genericRepository, mapper)
    {
        _sessionAttendanceRepository = sessionAttendanceRepository;
    }

    public async Task<List<SessionAttendanceDto>> GetSessionAttendances(Guid sessionId)
    {
        var list = await _sessionAttendanceRepository.GetSessionAttendances(sessionId);

        return Mapper.Map<List<SessionAttendanceDto>>(list);
    }

    public async Task DeleteAsync(Guid sessionId, Guid userId)
    {
        await _sessionAttendanceRepository.DeleteAsync(sessionId, userId);
    }

    public async Task CreateSessionAttendances(List<SessionAttendanceDto> sessionAttendances)
    {
        var list = Mapper.Map<List<SessionAttendance>>(sessionAttendances);
        await _sessionAttendanceRepository.AddList(list);
    }
}