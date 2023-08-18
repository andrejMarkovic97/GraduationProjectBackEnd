using Application.GenericService;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.Helper;
using AutoMapper;
using Domain.Entities;

namespace ApplicationServices.CourseApplicationService;

public class CourseApplicationService : ICourseApplicationService
{
    private readonly IGenericService<Course> _genericService;
    private readonly IMapper _mapper;

    public CourseApplicationService(IGenericService<Course> genericService, IMapper mapper)
    {
        _genericService = genericService;
        _mapper = mapper;
    }
    public async Task<CourseReadDto> CreateAsync(CourseCreateUpdateDto dto)
    {
        var fileName = Guid.NewGuid().ToString() + "_" + dto.Image.FileName;
        ImageHelper.UploadImage(fileName, dto.Image);

        var course = _mapper.Map<Course>(dto);
        course.ImagePath = fileName;

        await _genericService.CreateAsync(course);

        return _mapper.Map<CourseReadDto>(course);
    }

    
}