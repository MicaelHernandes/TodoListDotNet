using System.ComponentModel.DataAnnotations;

namespace TodoListDotNet.DTOs;

public class TaskCreateDTO
{
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }
    [Required(ErrorMessage = "O status da tarefa é obrigatório")]
    public TaskStatus Status { get; set; }
    [Required(ErrorMessage = "A data de vencimento é obrigatória")]
    public DateTime DueDate { get; set; }
}