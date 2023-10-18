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
    public ClasseResposta PostClasse([FromBody] ClasseCriarAtualizarRequisicao novaClasse)
    {
        //Enviar dados para a camada de serviço
       var classeResposta = _classeServico.CriarClasse(novaClasse);

        //Retornando resposta
        return classeResposta;
    }


    [HttpGet]
    public List<ClasseResposta> GetClasses()
    {
        //retornar a resposta do metodo listas classes do servico
        return _classeServico.ListarClasses();
    }

    [HttpGet("{id:int}")]
    public ClasseResposta GetClasse([FromRoute] int id)
    {
        return _classeServico.BuscarClassePeloId(id);
    }

    [HttpDelete("{id:int}")]
    public void DeleteClasse([FromRoute] int id)
    {
        //Mandando o serviço excluir
        _classeServico.RemoverClasse(id);
    }

    [HttpPut("{id:int}")]
    public ClasseResposta PutClasse([FromRoute] int id, [FromBody] ClasseCriarAtualizarRequisicao classeEditada)
    {
        //Enviar para o serviço editar
        var classeResposta = _classeServico.AtualizarClasse(id, classeEditada);

        //Retornando para o app cliente (JSON)
        return classeResposta;
    }


}
