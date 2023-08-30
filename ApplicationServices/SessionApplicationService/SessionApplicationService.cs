
using ApplicationServices.DataTransferObjects.Session;
using ApplicationServices.GenericApplicationService;
using AutoMapper;
using DataAccess.GenericRepository;
using Domain.Entities;

namespace ApplicationServices.SessionApplicationService;

public class SessionApplicationService :  GenericApplicationService<Session,SessionDto> ,ISessionApplicationService
{
    public SessionApplicationService(IGenericRepository<Session> genericRepository, IMapper mapper) 
        : base(genericRepository, mapper)
    {
        
    }
    
    public async Task<List<SessionDto>> GetCourseSessions(Guid id)
    {
        var list = await GenericRepository.GetListById(id);
        return Mapper.Map<List<SessionDto>>(list);
    }

    public override async Task<SessionDto> CreateAsync(SessionDto dto)
    {
        var session = Mapper.Map<Session>(dto);

        session.SessionId = session.SessionId == Guid.Empty
            ? Guid.NewGuid()
            : session.SessionId;

        await GenericRepository.AddAsync(session);
        return dto;
    }

    
}