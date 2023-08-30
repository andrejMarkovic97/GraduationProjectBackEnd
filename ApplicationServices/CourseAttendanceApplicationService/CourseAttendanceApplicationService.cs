using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.GenericApplicationService;
using AutoMapper;
using DataAccess.CourseAttendanceRepository;
using DataAccess.CourseAttendancesQueryRepository;
using DataAccess.GenericRepository;
using Domain.Entities;

namespace ApplicationServices.CourseAttendanceApplicationService;

public class CourseAttendanceApplicationService : GenericApplicationService<CourseAttendance, CourseAttendancePostDto>,
    ICourseAttendanceApplicationService
{
    private readonly ICourseAttendancesQueryRepository _queryRepository;
    private readonly ICourseAttendanceRepository _courseAttendanceRepository;

    public CourseAttendanceApplicationService(IGenericRepository<CourseAttendance> genericRepository,
        IMapper mapper, ICourseAttendancesQueryRepository queryRepository,
        ICourseAttendanceRepository courseAttendanceRepository)
        : base(genericRepository, mapper)
    {
        _queryRepository = queryRepository;
        _courseAttendanceRepository = courseAttendanceRepository;
    }

    public async Task<List<CourseAttendanceDto>> GetCourseAttendances(Guid id)
    {
        var list = await _queryRepository.GetCourseAttendances(id);

        return Mapper.Map<List<CourseAttendanceDto>>(list);
    }


    public async Task CreateCourseAttendances(List<CourseAttendancePostDto> attendances)
    {
        var list = Mapper.Map<List<CourseAttendance>>(attendances);
        await _courseAttendanceRepository.AddList(list);
    }

    public async Task DeleteAsync(Guid courseId, Guid userId)
    {
        await _courseAttendanceRepository.DeleteAsync(courseId, userId);
    }
}