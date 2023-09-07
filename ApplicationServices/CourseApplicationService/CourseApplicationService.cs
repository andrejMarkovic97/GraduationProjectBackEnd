using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.GenericApplicationService;
using ApplicationServices.Helper;
using AutoMapper;
using DataAccess.CourseRepository;
using DataAccess.GenericRepository;
using DataAccess.UserRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ApplicationServices.CourseApplicationService;

public class CourseApplicationService : GenericApplicationService<Course,CourseReadDto>, ICourseApplicationService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUserRepository _userRepository;


    public CourseApplicationService(IGenericRepository<Course> genericRepository, IMapper mapper, ICourseRepository courseRepository, IUserRepository userRepository) 
        : base(genericRepository, mapper)
    {
        _courseRepository = courseRepository;
        _userRepository = userRepository;
    }
    public async Task<CourseCreateUpdateGetDto> CreateAsync(CourseCreateUpdatePostDto postDto)
    {
        var course = Mapper.Map<Course>(postDto);

        if (course.CourseId == Guid.Empty)
        {
            course.CourseId = Guid.NewGuid();
        }

        course.ImagePath = UploadImage(course.CourseId, postDto.Image);

        await _courseRepository.AddAsync(course);

        return Mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    private static string UploadImage(Guid id, IFormFile image)
    {
        var fileName = id + "_" + image.FileName;
        ImageHelper.UploadImage(id, image);

        return $"images/{fileName}";
    }

    public override async Task<List<CourseReadDto>> GetAllAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return Mapper.Map<List<CourseReadDto>>(courses);
    }


    public new async Task<CourseCreateUpdateGetDto> GetByIdAsync(Guid id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        return Mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    public async Task<CourseCreateUpdateGetDto> UpdateAsync(CourseCreateUpdatePostDto dto)
    {
        var course = Mapper.Map<Course>(dto);

        course.ImagePath = UploadImage(course.CourseId, dto.Image);

        await _courseRepository.UpdateAsync(course);

        return Mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    public async Task<List<UserDto>> GetUsersNotAttendingCourse(Guid id)
    {
        var list = await _userRepository.GetUsersNotAttendingCourse(id);

        return Mapper.Map<List<UserDto>>(list);
    }

   
}