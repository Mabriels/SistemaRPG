using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaRPG.Models;

[Index(nameof(Email), IsUnique = true)]
public class Usuario
{
    [Required]
    public int Id { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Nome { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Email { get; set; }

    [Required]
    [Column(TypeName = "varchar(80)")]
    public string Senha { get; set; }

    //Propriedades de navegação
    public List<Personagem> Personagens { get; set; }
}
