using Microsoft.EntityFrameworkCore;
using TodoListDotNet.Models;
using Task = TodoListDotNet.Models.Task;

namespace TodoListDotNet.Infra.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}