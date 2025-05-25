using Microsoft.EntityFrameworkCore;
using TodoListDotNet.Infra.Context;

namespace TodoListDotNet.Infra.Repositories.User;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Models.User> getUserById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<Models.User> getUserByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Mail == email);
    }

    public async Task<Models.User> addUser(Models.User user)
    {
        var newUser = await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<Models.User> updateUser(Models.User user)
    {
        var updatedUser = _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return updatedUser.Entity;
    }

    public async Task<bool> deleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        _context.Users.Remove(user);
        return true;
    }
}