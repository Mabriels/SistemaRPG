using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Raca;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class RacaServico
{
    
    private RacaRepositorio _racaRepositorio;

    public RacaServico([FromServices] RacaRepositorio repositorio)
    {
        _racaRepositorio = repositorio;
    }


    public RacaResposta CriarRaca(RacaCriarAtualizarRequisicao novaRaca)
    {

        Raca raca = new();

        raca.Nome = novaRaca.Nome;


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

        raca = _racaRepositorio.CriarRaca(raca);


        var racaResposta = ConverterModeloParaResposta(raca);

        return racaResposta;
    }


    public List<RacaResposta> ListarRacas()
    {
        var racas = _racaRepositorio.ListarRacas();

        List<RacaResposta> racaRespostas = new();

        foreach(var raca in racas)
        {
            var racaResposta = ConverterModeloParaResposta(raca);

            racaRespostas.Add(racaResposta);
        }

        return racaRespostas;

    }

    public RacaResposta BuscarRacaPeloId(int id)
    {
        var raca = _racaRepositorio.BuscarRacaPeloId(id);

        if(raca is null)
        {
            return null;
        }

        var racaResposta = ConverterModeloParaResposta(raca);

        return racaResposta;
    }

    private RacaResposta ConverterModeloParaResposta(Raca modelo)
    {
        var racaResposta = new RacaResposta();
        racaResposta.Id = modelo.Id;
        racaResposta.Nome = modelo.Nome;
        racaResposta.Atributo = modelo.Atributo;

        return racaResposta;
    }
}
