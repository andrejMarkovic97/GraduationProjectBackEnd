using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.DataTransferObjects.TopicDto;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AuthModels;

namespace ApplicationServices.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        //User
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<LoginUserDto, User>();
        CreateMap<RegisterUserDto, User>();

        //Course
        CreateMap<CourseCreateUpdatePostDto, Course>()
            .ForMember(dest => dest.ImagePath, opt => opt.Ignore());
        CreateMap<Course, CourseCreateUpdateGetDto>();
        CreateMap<Course, CourseReadDto>();
        CreateMap<CourseCreateUpdatePostDto, Course>();
        
        //Category
        CreateMap<Category,CategoryReadDto>();
        
        //Topic
        CreateMap<Topic,TopicReadDto>();
    }
}