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
        DefinicaoClasses(classe);

        //Enviar para o BD atraves do repositorio
        classe = _classeRepositorio.CriarClasse(classe);


        //Copiar os modelos para a resposta
        var classeResposta = ConverterModeloParaResposta(classe);

        return classeResposta;
    }

    public List<ClasseResposta> ListarClasses()
    {
        //Pedir ao repositorio todos as classes
        var classes = _classeRepositorio.ListarClasses();

        //Copiar os dados dos modelos para as respostas
        List<ClasseResposta> classeRespostas = new(); //Lista vazia
        
        foreach(var classe in classes)
        {
            var classeResposta = ConverterModeloParaResposta(classe);

            //adicionar na lista 
            classeRespostas.Add(classeResposta);

        }

        //Retornar a lista de respostas
        return classeRespostas;
    }

    public ClasseResposta BuscarClassePeloId(int id)
    {
        //Pedir ao repositorio buscar pelo id
        var classe = _classeRepositorio.BuscarClassePeloId(id);

        if(classe is null)
        {
            return null; //No futuro vou mudar para uma exceção
        }

        //Copiar do modelo para a resposta
        var classeResposta = ConverterModeloParaResposta(classe);

        //retornando a resposta
        return classeResposta;
    }

    public void RemoverClasse(int id)
    {

        //Se tiver alguma regra de negócio que tem que fazer antes de remover pode colocar aqui

        //Buscando o procedimento que deseja remover
        var classe = _classeRepositorio.BuscarClassePeloId(id);

        if(classe is null)
        {
            return; //Vai ser uma exceção no futuro
        }

        //Mandar para o repositorio remover
        _classeRepositorio.RemoverClasse(classe);

    }


    public ClasseResposta AtualizarClasse(int id, ClasseCriarAtualizarRequisicao classeEditada)
    {
        //Buscar a classe no BD para poder edita-lo
        var classe = _classeRepositorio.BuscarClassePeloId(id);

        if(classe is null)
        {
            return null; //No futuro vai ser uma exceção (erro)
        }

        //Copiar os dados da requisição para o modelo
        classe.Nome = classeEditada.Nome;

        //Regras de negocio especificas
        DefinicaoClasses(classe);

        //Mandar o repositorio salvar no BD
        _classeRepositorio.AtualizarClasse();

        //Copiar os dados do modelo para resposta
        var classeResposta = ConverterModeloParaResposta(classe);

        //Retornando a resposta para o controllador
        return classeResposta;



    }


    private ClasseResposta ConverterModeloParaResposta(Classe modelo)
    {
        var classeResposta = new ClasseResposta();
        classeResposta.Id = modelo.Id;
        classeResposta.Nome = modelo.Nome;
        classeResposta.Atributo = modelo.Atributo;

        return classeResposta;
    }

    private Classe DefinicaoClasses(Classe classe)
    {
        if(classe.Nome == "Mago")
        {
            classe.Atributo = "DEF: 3, FOR: 3, INT: 6, STM: 3";
        }
        else if(classe.Nome == "Guerreiro")
        {
            classe.Atributo = "DEF: 3, FOR: 6, INT: 2, STM: 4";
        }
        else if(classe.Nome == "Arqueiro")
        {
            classe.Atributo = "DEF: 2, FOR: 3, INT: 5, STM: 5";
        }
        else if(classe.Nome == "Curandeiro")
        {
            classe.Atributo = "DEF: 4, FOR: 3, INT: 5, STM: 3";
        }
        else
        {
            classe.Atributo = "DEF: 3, FOR: 3, INT: 3, STM: 6";
        }

        return classe;
    }
}
