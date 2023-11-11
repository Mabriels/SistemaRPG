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
    public ActionResult<RacaResposta> PostRaca([FromBody] RacaCriarAtualizarRequisicao novaRaca)
    {
        var racaResposta = _racaServico.CriarRaca(novaRaca);

        // return racaResposta;

        // return StatusCode(201, racaResposta);
        return CreatedAtAction(nameof(GetRaca), new {id = racaResposta.Id}, racaResposta);
    }

    [HttpGet]
    public ActionResult<List<RacaResposta>> GetRacas()
    {
        return Ok(_racaServico.ListarRacas());
    }
    

    [HttpGet("{id:int}")]
    public ActionResult<RacaResposta> GetRaca([FromRoute] int id)
    {
        try
        {
            return Ok(_racaServico.BuscarRacaPeloId(id));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
        
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteRaca([FromRoute] int id)
    {
        try
        {
            _racaServico.RemoverRaca(id); 

            return NoContent();
        }
        catch (Exception e)
        {
           return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<RacaResposta> PutRaca([FromRoute] int id, [FromBody] RacaCriarAtualizarRequisicao racaEditada)
    {
        try
        {
            return Ok(_racaServico.AtualizarRaca(id, racaEditada));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }

    }
}
