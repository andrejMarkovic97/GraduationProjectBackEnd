using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.Helper;
using AutoMapper;
using DataAccess.GenericRepository;
using DataAccess.UserRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ApplicationServices.CourseApplicationService;

public class CourseApplicationService : ICourseApplicationService
{
    private readonly IGenericRepository<Course> _courseRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly IGenericRepository<CourseAttendance> _courseAttendanceRepository;

    public CourseApplicationService(IGenericRepository<Course> courseRepository, IMapper mapper,
        IUserRepository userRepository,
        IGenericRepository<CourseAttendance> courseAttendanceRepository)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _userRepository = userRepository;
        _courseAttendanceRepository = courseAttendanceRepository;
    }

    public async Task<CourseCreateUpdateGetDto> CreateAsync(CourseCreateUpdatePostDto postDto)
    {
        var course = _mapper.Map<Course>(postDto);

        if (course.CourseId == Guid.Empty)
        {
            course.CourseId = Guid.NewGuid();
        }

        course.ImagePath = UploadImage(course.CourseId, postDto.Image);

        await _courseRepository.AddAsync(course);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    private static string UploadImage(Guid id, IFormFile image)
    {
        var fileName = id + "_" + image.FileName;
        ImageHelper.UploadImage(id, image);

        return $"images/{fileName}";
    }

    public async Task<List<CourseReadDto>> GetAllAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return _mapper.Map<List<CourseReadDto>>(courses);
    }


    public async Task<CourseCreateUpdateGetDto> GetByIdAsync(Guid id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    public async Task<CourseCreateUpdateGetDto> UpdateAsync(CourseCreateUpdatePostDto dto)
    {
        var course = _mapper.Map<Course>(dto);

        course.ImagePath = UploadImage(course.CourseId, dto.Image);

        await _courseRepository.UpdateAsync(course);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    public async Task<List<UserDto>> GetUsersNotAttendingCourse(Guid id)
    {
        var list = await _userRepository.GetUsersNotAttendingCourse(id);

        return _mapper.Map<List<UserDto>>(list);
    }

}