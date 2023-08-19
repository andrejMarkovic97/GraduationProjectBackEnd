using Application.GenericService;
using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.Helper;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace ApplicationServices.CourseApplicationService;

public class CourseApplicationService : ICourseApplicationService
{
    private readonly IGenericService<Course> _courseService;
    private readonly IGenericService<Category> _categoryService;
    private readonly IMapper _mapper;

    public CourseApplicationService(IGenericService<Course> courseService, IGenericService<Category> categoryService, IMapper mapper)
    {
        _courseService = courseService;
        _categoryService = categoryService;
        _mapper = mapper;
    }
    public async Task<CourseCreateUpdateGetDto> CreateAsync(CourseCreateUpdatePostDto postDto)
    {
        var course = _mapper.Map<Course>(postDto);
        
        course.ImagePath = UploadImage(course.CourseId, postDto.Image);

        await _courseService.CreateAsync(course);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    private static string UploadImage(Guid id, IFormFile image)
    {
        var fileName = Guid.NewGuid() + "_" + image.FileName;
        ImageHelper.UploadImage(id, image);
        
        return $"images/{fileName}";
    }

    public async Task<List<CourseReadDto>> GetAllAsync()
    {
        var courses = await _courseService.GetAllAsync();

        return _mapper.Map<List<CourseReadDto>>(courses);
    }


    public async Task<CourseCreateUpdateGetDto> GetByIdAsync(Guid id)
    {
        var course = await _courseService.GetByIdAsync(id);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }

    public async Task<CourseCreateUpdateGetDto> UpdateAsync(CourseCreateUpdatePostDto dto)
    {
        var course = _mapper.Map<Course>(dto);

        course.ImagePath = UploadImage(course.CourseId, dto.Image);

        await _courseService.UpdateAsync(course);

        return _mapper.Map<CourseCreateUpdateGetDto>(course);
    }
}