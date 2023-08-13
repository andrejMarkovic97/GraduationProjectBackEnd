using Application.DataTransferObjects;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}