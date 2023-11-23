using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;

public class Classe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Atributo { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }


    //Propriedade de Navegação
    public List<Personagem> Personagens { get; set; }

    public List<Equipamento> Equipamentos { get; set; }

}
