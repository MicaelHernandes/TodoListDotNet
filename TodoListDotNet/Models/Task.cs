using System.ComponentModel.DataAnnotations;

namespace TodoListDotNet.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    [Length(1,250, ErrorMessage = "Insira uma descrição entre 1 e 250 caracteres")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O status da tarefa é obrigatório")]
    public TaskStatus Status { get; set; }
    public User Owner { get; set; }

    public Task()
    {
        
    }
    
    public Task(string descricao, TaskStatus status, User owner)
    {
        Descricao = descricao;
        Status = status;
        Owner = owner;
    }
}