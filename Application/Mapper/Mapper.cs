using Application.DataTransferObjects;
using AutoMapper;
using Domain.Entities;
using Infrastructure.AuthModels;

namespace Application.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<LoginUserDto, User>();
        CreateMap<RegisterUserDto, User>();
    }
}