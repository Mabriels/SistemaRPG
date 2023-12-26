using SistemaRPG.DTOs.Classe;
using SistemaRPG.DTOs.Raca;
using SistemaRPG.DTOs.Usuario;

namespace SistemaRPG.DTOs.Personagem;

public class PersonagemResposta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public decimal Dinheiro { get; set; }
    public int UsuarioId { get; set; }
    public UsuarioResposta Usuario { get; set; }
    public int ClasseId { get; set; }
    public ClasseResposta Classe { get; set; }
    public int RacaId { get; set; }
    public RacaResposta Raca { get; set; }
}
