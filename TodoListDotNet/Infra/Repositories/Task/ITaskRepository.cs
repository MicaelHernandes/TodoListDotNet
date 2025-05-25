namespace TodoListDotNet.Infra.Repositories.Task;

public interface ITaskRepository
{
    Task<Models.Task?> GetById(int id);
    Task<Models.Task> Create(Models.Task task);
    Task<Models.Task> Update(Models.Task task);
    Task<bool> Delete(int id);
    Task<IEnumerable<Models.Task>> GetByUserId(int userId);
}