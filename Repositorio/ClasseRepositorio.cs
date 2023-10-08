using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Data;
using SistemaRPG.Models;

namespace SistemaRPG.Repositorio;

public class ClasseRepositorio
{
    
    private ContextoBD _contexto;

    public ClasseRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }
    public Classe CriarClasse(Classe classe)
    {
        //Mandar salvar no contexto
        _contexto.Classes.Add(classe);
        _contexto.SaveChanges();

        return classe;
    }
}
