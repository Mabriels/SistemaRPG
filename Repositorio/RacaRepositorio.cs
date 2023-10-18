using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Data;
using SistemaRPG.Models;

namespace SistemaRPG.Repositorio;

public class RacaRepositorio
{
    
    private ContextoBD _contexto;

    public RacaRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }


    public Raca CriarRaca(Raca raca)
    {
        _contexto.Racas.Add(raca);
        _contexto.SaveChanges();

        return raca;
    }

    public List<Raca> ListarRacas()
    {
        return _contexto.Racas.ToList();
    }

    public Raca BuscarRacaPeloId(int id)
    {
        return _contexto.Racas.FirstOrDefault(raca => raca.Id == id);
    }

    public void RemoverRaca(Raca raca)
    {
        _contexto.Remove(raca);

        _contexto.SaveChanges();

    }

    public void AtualizarRaca()
    {
        _contexto.SaveChanges();
    }
}
