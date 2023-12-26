using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Data;

namespace SistemaRPG.Repositorio;

public class EquipamentoRepositorio
{
    private readonly ContextoBD _contexto;

    public EquipamentoRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

}
