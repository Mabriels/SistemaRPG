using System.ComponentModel.DataAnnotations;

namespace SistemaRPG.DTOs.Classe;

public class ClasseCriarAtualizarRequisicao
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }
}
