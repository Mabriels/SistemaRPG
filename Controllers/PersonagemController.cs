using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Personagem;
using SistemaRPG.Models;
using SistemaRPG.Services;

namespace SistemaRPG.Controllers;

[ApiController]
[Route("personagens")]
public class PersonagemController : ControllerBase
{

    private readonly PersonagemServico _personagemServico;

    public PersonagemController([FromServices] PersonagemServico servico)
    {
        _personagemServico = servico;
    }

    [HttpPost]
    public ActionResult<PersonagemResposta> PostPersonagem([FromBody] PersonagemCriarRequisicao novoPersonagem)
    {
        try
        {
            return StatusCode(201, _personagemServico.CriarPersonagem(novoPersonagem));
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet]
    public ActionResult<List<PersonagemResposta>> GetPersonagens()
    {
        return Ok(_personagemServico.ListarPersonagem());
    }


    [HttpGet("{id:int}")]
    public ActionResult<PersonagemResposta> GetPersonagem([FromRoute] int id)
    {
        try
        {
            return Ok(_personagemServico.BuscarPersonagemPeloId(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeletePersonagem([FromRoute] int id)
    {
        try
        {
            _personagemServico.RemoverPersonagem(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<PersonagemResposta> PutPersonagem([FromBody] PersonagemAtualizarRequisicao personagemEditado, [FromRoute] int id)
    {
        try
        {
            return Ok(_personagemServico.AtualizarPersonagem(id, personagemEditado));
        }
        catch (BadHttpRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }

    }

}
