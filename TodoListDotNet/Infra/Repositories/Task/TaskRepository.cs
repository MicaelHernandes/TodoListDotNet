using Microsoft.EntityFrameworkCore;
using TodoListDotNet.Infra.Context;
using TaskModel = TodoListDotNet.Models.Task;

namespace TodoListDotNet.Infra.Repositories.Task;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;
    
    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Models.Task?> GetById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Models.Task> Create(Models.Task task)
    {
        var newTask = await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return newTask.Entity;
    }

    public async Task<Models.Task> Update(Models.Task task)
    {
        var oldTask = await _context.Tasks.FindAsync(task.Id);
        if (oldTask == null)
        {
            throw new KeyNotFoundException("Task not found");
        }

        oldTask.Descricao = task.Descricao;
        oldTask.Status = task.Status;
        oldTask.Owner = task.Owner;
        oldTask.DueDate = task.DueDate;
        await _context.SaveChangesAsync();
        return oldTask;
    }

    public async Task<bool> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null)
        {
            throw new KeyNotFoundException("Task not found");
        }
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<TaskModel>> GetByUserId(int userId)
    {
        var tasks = await _context.Tasks.Where(t => t.OwnerId == userId).ToListAsync();
        return tasks;
    }
}