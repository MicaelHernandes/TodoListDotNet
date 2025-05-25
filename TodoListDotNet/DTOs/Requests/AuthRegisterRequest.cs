using System.ComponentModel.DataAnnotations;

namespace TodoListDotNet.DTOs.Requests;

public class AuthRegisterRequest
{
    [Required(ErrorMessage = "Nome do usuario é obrigatorio.")]
    [StringLength(100, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.", MinimumLength = 6)]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email do usuario é obrigatorio.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Senha do usuario é obrigatorio.")]
    [StringLength(100, ErrorMessage = "A senha deve ter entre 6 e 100 caracteres.", MinimumLength = 6)]
    public string Password { get; set; }
}