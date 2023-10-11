using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Raca;
using SistemaRPG.Services;

namespace SistemaRPG.Controllers;

[ApiController]
[Route("raca")]
public class RacaController : ControllerBase
{
    
    private RacaServico _racaServico;

    public RacaController([FromServices] RacaServico servico)
    {
        _racaServico = servico;
    }


    [HttpPost]
    public RacaResposta PostRaca([FromBody] RacaCriarAtualizarRequisicao novaRaca)
    {
        var racaResposta = _racaServico.CriarRaca(novaRaca);

        return racaResposta;
    }

    [HttpGet]
    public List<RacaResposta> GetRacas()
    {
        return _racaServico.ListarRacas();
    }
    

    [HttpGet("{id:int}")]
    public RacaResposta GetRaca([FromRoute] int id)
    {
        return _racaServico.BuscarRacaPeloId(id);
    }
}
