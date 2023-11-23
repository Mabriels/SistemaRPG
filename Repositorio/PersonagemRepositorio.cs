using Microsoft.AspNetCore.Mvc;
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
}
