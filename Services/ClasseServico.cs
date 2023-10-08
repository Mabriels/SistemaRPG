using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Classe;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class ClasseServico
{
    
    private ClasseRepositorio _classeRepositorio;

    public ClasseServico([FromServices] ClasseRepositorio repositorio)
    {
        _classeRepositorio = repositorio;
    }


    public ClasseResposta CriarClasse(ClasseCriarAtualizarRequisicao novaClasse)
    {
        //Todas as regras da requisicao
        Classe classe = new();
        classe.Nome = novaClasse.Nome;


        //Regras especificas
        if(classe.Nome == "Mago")
        {
            classe.Atributo = "DEF: 3, FOR: 3, INT: 6, STM: 3";
        }
        if(classe.Nome == "Guerreiro")
        {
            classe.Atributo = "DEF: 3, FOR: 6, INT: 2, STM: 4";
        }
        if(classe.Nome == "Arqueiro")
        {
            classe.Atributo = "DEF: 2, FOR: 3, INT: 5, STM: 5";
        }
        if(classe.Nome == "Curandeiro")
        {
            classe.Atributo = "DEF: 4, FOR: 3, INT: 5, STM: 3";
        }
        
        //Enviar para o BD atraves do repositorio
        classe = _classeRepositorio.CriarClasse(classe);


        //Copiar os modelos para a resposta
        ClasseResposta classeResposta = new ClasseResposta();
        classeResposta.Id = classe.Id;
        classeResposta.Nome = classe.Nome;
        classeResposta.Atributo = classe.Atributo;

        return classeResposta;
    }
}
