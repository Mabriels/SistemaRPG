using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace SistemaRPG.Models;


public class Personagem
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [Column(TypeName= "varchar(80)")]
    public string Nome { get; set; }
    
    [Required]
    public int Idade { get; set; }
    
    [Column(TypeName= "varchar(80)")]
    [Required]
    public string Atributo { get; set; }
    
    [Column(TypeName= "decimal(10,2)")]
    public decimal Dinheiro { get; set; }


    //Propriedade de Navegação
    public List<Classe> Classes { get; set; }
    public List<Raca> Racas { get; set; }
}
