using System.ComponentModel.DataAnnotations;

namespace TodoListDotNet.DTOs.Requests;

public class AuthRequest
{
    [Required(ErrorMessage = "Email é obrigatorio")]
    [EmailAddress(ErrorMessage = "Insira um email valido")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha é obrigatorio")]
    [StringLength(100, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres", MinimumLength = 6)]
    public string Password { get; set; }
}