using System.ComponentModel.DataAnnotations;

namespace SistemaRPG.DTOs.Personagem;

public class PersonagemCriarRequisicao
{
    [Required(ErrorMessage = "O campo {0} é obrigatório.")]
    [StringLength(80, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres")]
    public string Nome { get; set; }

    [Required]
    public int? Idade { get; set; }

    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string Atributo { get; set; }

    public decimal Dinheiro { get; set; }
    public int UsuarioId { get; set; }
    public int ClasseId { get; set; }
    public int RacaId { get; set; }
}
