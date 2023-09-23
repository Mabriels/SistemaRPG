using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;

public class Equipamento
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName="varchar(80)")]
    public string Atributo { get; set; }

    [Required]
    [Column(TypeName="decimal(10,2)")]
    public decimal Preco { get; set; }


    //Propriedade de Navegação
    public List<Classe> Classes { get; set; }
}
