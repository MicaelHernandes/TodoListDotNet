using System.ComponentModel.DataAnnotations;

namespace TodoListDotNet.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Length(3, 50)]
    public string Name { get; set; }
    [Length(3, 50)]
    public string Mail { get; set; }
    [Length(3, 100)]
    public string Password { get; set; }
    public IEnumerable<Task>? Tasks { get; set; }
    
    public User()
    {
        
    }
    
    public User(string name, string mail, string password)
    {
        Name = name;
        Mail = mail;
        Password = password;
    }
}