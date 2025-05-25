using TodoListDotNet.DTOs;
using TodoListDotNet.DTOs.Requests;

namespace TodoListDotNet.Services.Task;

public interface ITaskService
{
    Task<TaskDTO> GetById(int id);
    Task<IEnumerable<TaskDTO>> GetAll(int id);
    Task<TaskDTO> Create(TaskCreateDTO task, int ownerId);
    Task<TaskDTO> Update(TaskUpdateDTO task, int id, int ownerId);
    Task<bool> Delete(int id);
}