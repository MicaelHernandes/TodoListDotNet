using Microsoft.EntityFrameworkCore;

namespace TodoListDotNet.Infra.Context;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}