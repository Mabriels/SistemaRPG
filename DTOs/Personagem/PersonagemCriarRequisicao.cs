namespace SistemaRPG.DTOs.Personagem;

public class PersonagemCriarRequisicao
{
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Atributo { get; set; }
    public decimal Dinheiro { get; set; }
    public int ClasseId { get; set; }
    public int RacaId { get; set; }
    public int UsuarioId { get; set; }
}
