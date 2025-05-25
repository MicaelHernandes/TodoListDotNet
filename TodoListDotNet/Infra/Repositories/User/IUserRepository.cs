namespace TodoListDotNet.Infra.Repositories.User;
using TodoListDotNet.Models;

public interface IUserRepository
{
    Task<User> getUserById(int id);
    Task<User> getUserByEmail(string email);
    Task<User> addUser(User user);
    Task<User> updateUser(User user);
    Task<bool> deleteUser(int id);
}