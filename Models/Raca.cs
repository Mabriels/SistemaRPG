using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;

public class Raca
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Atributo { get; set; }


    //Propriedade de Navegação
    public Personagem Personagem { get; set; }

    //Chave estrangeira
    public int PersonagemId { get; set; }

}
