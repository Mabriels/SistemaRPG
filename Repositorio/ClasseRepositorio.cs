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

    public List<Classe> ListarClasses()
    {
        return _contexto.Classes.ToList();
    }

    public Classe BuscarClassePeloId(int id)
    {
        return _contexto.Classes.FirstOrDefault( classe => classe.Id == id );
    }
    
}
