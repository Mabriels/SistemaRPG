using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;

public class Classe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Atributo { get; set; }


    //Referenciamento 1:1
    //Propriedade de Navegação
    public Personagem Personagem { get; set; }

    //Referenciamento 1:N
    //Propriedade de Navegação
    public Equipamento Equipamento { get; set; }

    //Chave estrangeira
    public int PersonagemId { get; set; }
    public int EquipamentoId { get; set; }
}
