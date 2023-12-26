using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class EquipamentoServico
{

    private readonly EquipamentoRepositorio _repositorio;

    public EquipamentoServico([FromServices] EquipamentoRepositorio repositorio)
    {
        _repositorio = repositorio;
    }


}
