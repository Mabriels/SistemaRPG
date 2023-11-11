using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Classe;
using SistemaRPG.Services;

namespace SistemaRPG.Controllers;

[Controller]
[Route("classe")]
public class ClasseController : ControllerBase
{


    private ClasseServico _classeServico;
    public ClasseController([FromServices] ClasseServico servico)
    {
        _classeServico = servico;
    }


    [HttpPost]
    public ActionResult<ClasseResposta> PostClasse([FromBody] ClasseCriarAtualizarRequisicao novaClasse)
    {
        //Enviar dados para a camada de serviço
       var classeResposta = _classeServico.CriarClasse(novaClasse);

        //Retornando resposta
        // return classeResposta;

        // return StatusCode(201, classeResposta);

        return CreatedAtAction(nameof(GetClasse), new { id = classeResposta.Id}, classeResposta);
    }


    [HttpGet]
    public ActionResult<List<ClasseResposta>> GetClasses()
    {
        //retornar a resposta do metodo listas classes do servico
        return Ok(_classeServico.ListarClasses());
    }

    [HttpGet("{id:int}")]
    public ActionResult<ClasseResposta> GetClasse([FromRoute] int id)
    {
        try
        {
            return Ok(_classeServico.BuscarClassePeloId(id));
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteClasse([FromRoute] int id)
    {
        try
        {
            //Mandando o serviço excluir
            _classeServico.RemoverClasse(id);
            return NoContent();
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }

        
    }

    [HttpPut("{id:int}")]
    public ActionResult<ClasseResposta> PutClasse([FromRoute] int id, [FromBody] ClasseCriarAtualizarRequisicao classeEditada)
    {
        try
        {
            //Enviar para o serviço editar
            var classeResposta = _classeServico.AtualizarClasse(id, classeEditada);

            //Retornando para o app cliente (JSON)
            return classeResposta;
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }


}
