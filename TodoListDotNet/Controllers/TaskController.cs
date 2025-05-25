using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListDotNet.DTOs;
using TodoListDotNet.DTOs.Requests;
using TodoListDotNet.DTOs.Responses;
using TodoListDotNet.Services.Task;

namespace TodoListDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var tasks = await _taskService.GetAll(userId);
                return Ok(new ApiResponse<IEnumerable<TaskDTO>>(tasks, "Lista de tarefas obtida com sucesso"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao obter lista de tarefas", new List<string> { e.Message }));
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDTO taskDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var task = await _taskService.Create(taskDto, userId);
                return Created("/", new ApiResponse<TaskDTO>(task, "Task cadastrado com sucesso"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao cadastrar tarefa", new List<string> { e.Message }));
            }
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskUpdateDTO taskDto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var task = await _taskService.Update(taskDto, id, userId);
                return Ok(new ApiResponse<TaskDTO>(task, "Task atualizada com sucesso"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao atualizar tarefa", new List<string> { e.Message }));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await _taskService.Delete(id);
                return Ok(new ApiResponse<bool>(true, "Task deletada com sucesso"));
            }
            catch (Exception e)
            {
                return BadRequest(new ApiResponse<string>("Erro ao deletar tarefa", new List<string> { e.Message }));
            }
        }
    }
}
