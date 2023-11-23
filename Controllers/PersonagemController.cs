using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Models;
using SistemaRPG.Services;

namespace SistemaRPG.Controllers;

[ApiController]
[Route("personagens")]
public class PersonagemController : ControllerBase
{

    private readonly PersonagemServico _personagemServico;

    public PersonagemController([FromServices] PersonagemServico servico)
    {
        _personagemServico = servico;
    }
}
