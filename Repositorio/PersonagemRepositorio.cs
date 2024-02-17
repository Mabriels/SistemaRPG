using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRPG.Data;
using SistemaRPG.Models;

namespace SistemaRPG.Repositorio;

public class PersonagemRepositorio
{
    private readonly ContextoBD _contexto;

    public PersonagemRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    public Personagem CriarPersonagem(Personagem personagem)
    {
        _contexto.Personagens.Add(personagem);
        _contexto.SaveChanges();
        return personagem;
    }

    public Personagem BuscarPersonagemPeloNome(string nome)
    {
        return _contexto.Personagens.FirstOrDefault(p => p.Nome == nome);
    }

    public List<Personagem> ListarPersonagem()
    {
        return _contexto.Personagens
        .Include(a => a.Usuario)
        .Include(a => a.Classe)
        .Include(a => a.Raca)
        .AsNoTracking().ToList();
    }

    public Personagem BuscarPersonagemPeloId(int id, bool tracking = true)
    {
        return (tracking) ?
            _contexto.Personagens.FirstOrDefault(p => p.Id == id) :
            _contexto.Personagens.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }


    public void RemoverPersonagem(Personagem personagem)
    {
        _contexto.Remove(personagem);

        _contexto.SaveChanges();
    }

    public void AtualizarPersonagem()
    {
        _contexto.SaveChanges();
    }


    public List<Personagem> ExibirDados(int classeId, int usuarioId, int racaId)
    {
        return _contexto.Personagens.AsNoTracking().Where(p => p.ClasseId == classeId && p.RacaId == racaId && p.UsuarioId == usuarioId).ToList();
    }


}
