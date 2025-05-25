using AutoMapper;
using TodoListDotNet.DTOs;
using TodoListDotNet.DTOs.Requests;
using TodoListDotNet.Infra.Repositories.Task;

namespace TodoListDotNet.Services.Task;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;
    
    public TaskService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }
    
    public async Task<TaskDTO> GetById(int id)
    {
        try
        {
            var task = await _taskRepository.GetById(id);
            return _mapper.Map<TaskDTO>(task);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<TaskDTO>> GetAll(int userId)
    {
        try
        {
            var tasks = await _taskRepository.GetByUserId(userId);
            return _mapper.Map<IEnumerable<TaskDTO>>(tasks);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TaskDTO> Create(TaskCreateDTO task, int ownerId)
    {
        try
        {
            var newTask = new Models.Task
            {
                Descricao = task.Descricao,
                Status = task.Status,
                OwnerId = ownerId,
                DueDate = task.DueDate
            };
            var createdTask = await _taskRepository.Create(newTask);
            return _mapper.Map<TaskDTO>(createdTask);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<TaskDTO> Update(TaskUpdateDTO task, int taskId, int userId)
    {
        try
        {
            var taskToUpdate = await _taskRepository.GetById(taskId);
            if (taskToUpdate == null)
            {
                throw new KeyNotFoundException("Task não encontrada");
            }

            if (taskToUpdate.OwnerId != userId)
            {
                throw new UnauthorizedAccessException("Você não tem permissão para atualizar esta tarefa");
            }
            taskToUpdate.Descricao = task.Descricao;
            taskToUpdate.Status = task.Status;
            taskToUpdate.DueDate = task.DueDate;
            
            var updatedTask =await _taskRepository.Update(taskToUpdate);
            return _mapper.Map<TaskDTO>(updatedTask);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var taskToDelete = await _taskRepository.GetById(id);
            if (taskToDelete == null)
            {
                throw new KeyNotFoundException("Task não encontrada");
            }
            var deletedTask = await _taskRepository.Delete(taskToDelete.Id);
            return deletedTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}