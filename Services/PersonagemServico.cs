using Mapster;
using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Personagem;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class PersonagemServico
{

    private readonly PersonagemRepositorio _personagemRepositorio;

    public PersonagemServico([FromServices] PersonagemRepositorio repositorio)
    {
        _personagemRepositorio = repositorio;
    }

    public PersonagemResposta CriarPersonagem(PersonagemCriarRequisicao novoPersonagem)
    {
        var personagem = novoPersonagem.Adapt<Personagem>();

        //Regras especificas de negocio


        var personagemResposta = personagem.Adapt<PersonagemResposta>();

        return personagemResposta;
    }
}
