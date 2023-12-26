using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32.SafeHandles;
using SistemaRPG.Services;

namespace SistemaRPG.Controllers;


[ApiController]
[Route("equipamentos")]
public class EquipamentoController
{

    private readonly EquipamentoServico _servico;

    public EquipamentoController([FromServices] EquipamentoServico servico)
    {
        _servico = servico;
    }
}
