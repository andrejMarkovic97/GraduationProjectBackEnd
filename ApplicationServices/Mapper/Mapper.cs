using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Category;
using ApplicationServices.DataTransferObjects.Course;
using ApplicationServices.DataTransferObjects.Session;
using ApplicationServices.DataTransferObjects.SessionAttendance;
using ApplicationServices.DataTransferObjects.TopicDto;
using AutoMapper;
using DataAccess.QueryModels;
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
        CreateMap< Course, CourseWithSessionsDto>();
        
        //Course Attendances
        CreateMap<CourseAttendancesQueryModel, CourseAttendanceDto>();
        CreateMap<CourseAttendancePostDto, CourseAttendance>();
        
        //Session
        CreateMap<Session, SessionDto>()
            .ForMember(dest => dest.Date, opt 
                => opt.MapFrom(src => src.SessionDate.ToShortDateString()))
            .ForMember(dest => dest.Time, opt 
                => opt.MapFrom(src => src.SessionDate.ToShortDateString()))
            .ConstructUsing(src => new SessionDto(src.SessionId, src.Address, 
                src.City, src.Country, 
                src.SessionDate.ToShortDateString(), src.SessionDate.ToString("HH:mm:ss"), 
                src.CourseId));
        
        CreateMap<SessionDto, Session>()
            .ForMember(dest => dest.SessionDate,
                opt => opt
                    .MapFrom(src => DateTime.Parse($"{src.Date} {src.Time}")));
        
        //Session Attendances
        CreateMap<SessionAttendance, SessionAttendanceDto>()
            .ForMember(dest => dest.FirstName,
                opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.LastName,
            opt => opt.MapFrom(src => src.User.LastName));
        
        //Category
        CreateMap<Category,CategoryReadDto>();
        
        //Topic
        CreateMap<Topic,TopicReadDto>();
    }
}