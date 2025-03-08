using System.ComponentModel.DataAnnotations;

namespace MFER.App.ViewModels;

public class ContatoViewModel
{
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    public string Telefone { get; set; }
    
    public string? Mensagem { get; set; }
}