using AutoMapper;
using TodoListDotNet.DTOs;
using TodoListDotNet.Models;
using Task = TodoListDotNet.Models.Task;

namespace TodoListDotNet.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<TaskDTO, Task>().ReverseMap();
    }
}