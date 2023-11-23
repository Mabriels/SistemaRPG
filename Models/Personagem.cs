using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;


public class Personagem
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Nome { get; set; }

    [Required]
    public int Idade { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Atributo { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Dinheiro { get; set; }

    [Required]
    public DateTime DataCriacao { get; set; }


    //Propriedade de Navegação
    public Classe Classe { get; set; }
    public Raca Raca { get; set; }
    public Usuario Usuario { get; set; }

    //Chave Estrangeira
    public int ClasseId { get; set; }
    public int RacaId { get; set; }
    public int UsuarioId { get; set; }
}
