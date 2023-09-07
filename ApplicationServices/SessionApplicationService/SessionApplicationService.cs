using System.Globalization;
using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Session;
using ApplicationServices.GenericApplicationService;
using AutoMapper;
using DataAccess.GenericRepository;
using DataAccess.UserRepository;
using Domain.Entities;

namespace ApplicationServices.SessionApplicationService;

public class SessionApplicationService : GenericApplicationService<Session, SessionDto>, ISessionApplicationService
{
    private readonly IUserRepository _userRepository;

    public SessionApplicationService(IGenericRepository<Session> genericRepository, IMapper mapper,
        IUserRepository userRepository)
        : base(genericRepository, mapper)
    {
        _userRepository = userRepository;
    }

    public async Task<List<SessionDto>> GetCourseSessions(Guid id)
    {
        var list = await GenericRepository.GetListById(id);
        return Mapper.Map<List<SessionDto>>(list);
    }

    public async Task<List<UserDto>> GetUsersNotAttendingSession(Guid id)
    {
        var list = await _userRepository.GetUsersNotAttendingSession(id);

        return Mapper.Map<List<UserDto>>(list);
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

    public override async Task<SessionDto?> GetByIdAsync(Guid id)
    {
        var session = await GenericRepository.GetByIdAsync(id);

        var timeParts = session.SessionDate.ToString().Split(' ');


        var dto = new SessionDto(session.SessionId, session.Address, session.City, session.Country,
            GetDate(timeParts[0]),
            timeParts[1], session.CourseId);

        return dto;
    }

    private string GetDate(string dateString)
    {
        string inputFormat = "dd.MM.yyyy.";


        string outputFormat = "yyyy-MM-dd";

        DateTime parsedDate;

        if (DateTime.TryParseExact(dateString, inputFormat, null, DateTimeStyles.None, out parsedDate))
        {
            // Format the DateTime into the desired output format
            string formattedDate = parsedDate.ToString(outputFormat);

            return formattedDate;
        }

        return dateString;
    }
}