using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaRPG.DTOs.Personagem;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class PersonagemServico
{

    private readonly PersonagemRepositorio _personagemRepositorio;
    private readonly ClasseRepositorio _classeRepositorio;
    private readonly UsuarioRepositorio _usuarioRepositorio;
    private readonly RacaRepositorio _racaRepositorio;

    public PersonagemServico([FromServices] PersonagemRepositorio repositorio, [FromServices] ClasseRepositorio cRepostiorio,
        [FromServices] UsuarioRepositorio uRepositorio, [FromServices] RacaRepositorio rRepositorio)
    {
        _personagemRepositorio = repositorio;
        _classeRepositorio = cRepostiorio;
        _usuarioRepositorio = uRepositorio;
        _racaRepositorio = rRepositorio;
    }


    public void CarregarDados(int classeId, int usuarioId, int racaId)
    {
        _personagemRepositorio.ExibirDados(classeId, usuarioId, racaId);
        _classeRepositorio.BuscarClassePeloId(classeId);
        _usuarioRepositorio.BuscarUsuarioPeloId(usuarioId);
        _racaRepositorio.BuscarRacaPeloId(racaId);
    }
    public PersonagemResposta CriarPersonagem(PersonagemCriarRequisicao novoPersonagem)
    {
        var personagemExistente = _personagemRepositorio.BuscarPersonagemPeloNome(novoPersonagem.Nome);
        if (personagemExistente is not null)
        {
            throw new BadHttpRequestException("Nome já cadastrado!");
        }

        CarregarDados(novoPersonagem.ClasseId, novoPersonagem.UsuarioId, novoPersonagem.RacaId);

        var personagem = novoPersonagem.Adapt<Personagem>();

        //Regras especificas de negocio
        var agora = DateTime.Now;
        personagem.DataCriacao = agora;

        personagem = _personagemRepositorio.CriarPersonagem(personagem);

        var personagemResposta = personagem.Adapt<PersonagemResposta>();

        return personagemResposta;
    }


    public List<PersonagemResposta> ListarPersonagem()
    {
        var personagens = _personagemRepositorio.ListarPersonagem();


        var personagemResposta = personagens.Adapt<List<PersonagemResposta>>();

        return personagemResposta;
    }


    public PersonagemResposta BuscarPersonagemPeloId(int id)
    {

        var personagem = BuscarPeloId(id, false);

        return personagem.Adapt<PersonagemResposta>();


    }

    public void RemoverPersonagem(int id)
    {
        var personagem = BuscarPeloId(id);

        _personagemRepositorio.RemoverPersonagem(personagem);
    }

    public PersonagemResposta AtualizarPersonagem(int id, PersonagemAtualizarRequisicao personagemEditado)
    {
        var personagemExistente = _personagemRepositorio.BuscarPersonagemPeloNome(personagemEditado.Nome);
        if (personagemExistente is not null)
        {
            throw new BadHttpRequestException("Nome já cadastrado!");
        }

        var personagem = BuscarPeloId(id);

        personagemEditado.Adapt(personagem);


        _personagemRepositorio.AtualizarPersonagem();

        var personagemResposta = personagem.Adapt<PersonagemResposta>();

        return personagemResposta;
    }

    private Personagem BuscarPeloId(int id, bool tracking = true)
    {
        var personagem = _personagemRepositorio.BuscarPersonagemPeloId(id);

        if (personagem is null)
        {
            throw new Exception("Personagem não existe");
        }

        return personagem;
    }

}
