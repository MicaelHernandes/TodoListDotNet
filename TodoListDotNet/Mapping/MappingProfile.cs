using AutoMapper;
using TodoListDotNet.DTOs;
using TodoListDotNet.Models;

namespace TodoListDotNet.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
    }
}