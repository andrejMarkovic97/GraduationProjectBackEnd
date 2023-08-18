using ApplicationServices.DataTransferObjects;
using ApplicationServices.DataTransferObjects.Course;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AuthModels;

namespace ApplicationServices.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<LoginUserDto, User>();
        CreateMap<RegisterUserDto, User>();

        CreateMap<CourseCreateUpdateDto, Domain.Entities.Course>()
            .ForMember(dest => dest.ImagePath, opt => opt.Ignore());

        CreateMap<Domain.Entities.Course, CourseReadDto>();
    }
}