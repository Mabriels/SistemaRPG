using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Raca;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;
using Mapster;

namespace SistemaRPG.Services;

public class RacaServico
{
    
    private readonly RacaRepositorio _racaRepositorio;

    public RacaServico([FromServices] RacaRepositorio repositorio)
    {
        _racaRepositorio = repositorio;
    }


    public RacaResposta CriarRaca(RacaCriarAtualizarRequisicao novaRaca)
    {

        var raca = novaRaca.Adapt<Raca>();

       

        //Regras especificas
        DefinicaoRaca(raca);
        var agora = DateTime.Now;
        raca.DataCriacao = agora;
        

        raca = _racaRepositorio.CriarRaca(raca);


        var racaResposta = raca.Adapt<RacaResposta>();

        return racaResposta;
    }


    public List<RacaResposta> ListarRacas()
    {
        var racas = _racaRepositorio.ListarRacas();

        var racaResposta = racas.Adapt<List<RacaResposta>>();

        return racaResposta;
    }

    public RacaResposta BuscarRacaPeloId(int id)
    {
        var raca = BuscarPeloId(id, false);


        return raca.Adapt<RacaResposta>();;
    }

    public void RemoverRaca(int id)
    {
        var raca = BuscarPeloId(id);

        _racaRepositorio.RemoverRaca(raca);
    }

    public RacaResposta AtualizarRaca(int id, RacaCriarAtualizarRequisicao racaEditada)
    {
        //Buscando a raça no BD
        var raca = BuscarPeloId(id);

        //Copiando os dados da requisicao para o modelo
        racaEditada.Adapt(raca);

        //Regra Especifica
        DefinicaoRaca(raca);

        //Mandando para o repositorio atualizar
        _racaRepositorio.AtualizarRaca();

        //Copiando o modelo para resposta com o metodo criado
        var racaResposta = raca.Adapt<RacaResposta>();

        //Retornando para o controlador
        return racaResposta;

    }



    private Raca DefinicaoRaca(Raca raca)
    {
        if(raca.Nome == "Elfo")
        {
            raca.Atributo = "DEF: 3, FOR: 4, INT: 5, STM: 3";
        }

        else if(raca.Nome == "Humano")
        {
            raca.Atributo = "DEF: 4, FOR: 4, INT: 3, STM: 4";
        }

        else if(raca.Nome == "Anão")
        {
            raca.Atributo = "DEF: 4, FOR: 6, INT: 2, STM: 3";
        }

        else
        {
            raca.Atributo = "DEF: 3, FOR: 3, INT: 3, STM: 6";
        }

        return raca;
    }

    private Raca BuscarPeloId(int id, bool tracking = true)
    {
        var raca = _racaRepositorio.BuscarRacaPeloId(id, tracking);

        if (raca is null)
        {
            throw new Exception("Raça não encontrada!");
        }

        return raca;
    }
}
