using Microsoft.AspNetCore.Mvc;
using SistemaRPG.DTOs.Classe;
using SistemaRPG.Models;
using SistemaRPG.Repositorio;
using Mapster;

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
        
        // //Todas as regras da requisicao
        // Classe classe = new();
        // classe.Nome = novaClasse.Nome;

        var classe = novaClasse.Adapt<Classe>();


        //Regras especificas
        DefinicaoClasses(classe);
        var agora = DateTime.Now;
        classe.DataCriacao = agora;

        //Enviar para o BD atraves do repositorio
        classe = _classeRepositorio.CriarClasse(classe);


        //Copiar os modelos para a resposta
        // var classeResposta = ConverterModeloParaResposta(classe);
        var classeResposta = classe.Adapt<ClasseResposta>();

        return classeResposta;
    }

    public List<ClasseResposta> ListarClasses()
    {
        //Pedir ao repositorio todos as classes
        var classes = _classeRepositorio.ListarClasses();

        //Copiar da lista de modelo para a lista de Resposta
        var classeRespostas = classes.Adapt<List<ClasseResposta>>();

        // //Copiar os dados dos modelos para as respostas
        // List<ClasseResposta> classeRespostas = new(); //Lista vazia
        
        // foreach(var classe in classes)
        // {
        //     var classeResposta = ConverterModeloParaResposta(classe);

        //     //adicionar na lista 
        //     classeRespostas.Add(classeResposta);

        // }

        // Retornar a lista de respostas
        return classeRespostas;

    }

    public ClasseResposta BuscarClassePeloId(int id)
    {
        //Pedir ao repositorio buscar pelo id
        var classe = BuscarPeloId(id, false);

        //Copiar do modelo para a resposta
        //var classeResposta = ConverterModeloParaResposta(classe);

        //retornando a resposta
        return classe.Adapt<ClasseResposta>();
    }

    public void RemoverClasse(int id)
    {

        //Se tiver alguma regra de negócio que tem que fazer antes de remover pode colocar aqui

        //Buscando o procedimento que deseja remover
        var classe = BuscarPeloId(id);

        //Mandar para o repositorio remover
        _classeRepositorio.RemoverClasse(classe);

    }


    public ClasseResposta AtualizarClasse(int id, ClasseCriarAtualizarRequisicao classeEditada)
    {
        //Buscar a classe no BD para poder edita-lo
        var classe = BuscarPeloId(id);

        //Copiar os dados da requisição para o modelo
        // classe.Nome = classeEditada.Nome;
        classeEditada.Adapt(classe);

        //Regras de negocio especificas
        DefinicaoClasses(classe);

        //Mandar o repositorio salvar no BD
        _classeRepositorio.AtualizarClasse();

        //Copiar os dados do modelo para resposta
        // var classeResposta = ConverterModeloParaResposta(classe);

        //Retornando a resposta para o controllador
        return classe.Adapt<ClasseResposta>();



    }


    // private ClasseResposta ConverterModeloParaResposta(Classe modelo)
    // {
    //     var classeResposta = new ClasseResposta();
    //     classeResposta.Id = modelo.Id;
    //     classeResposta.Nome = modelo.Nome;
    //     classeResposta.Atributo = modelo.Atributo;
    //     classeResposta.DataCriacao = modelo.DataCriacao;

    //     return classeResposta;
    // }

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

    private Classe BuscarPeloId(int id, bool tracking = true)
    {
        var classe = _classeRepositorio.BuscarClassePeloId(id, tracking);

        if(classe is null)
        {
            throw new Exception("Classe não encontrada!");
        }

        return classe;
    }
}
