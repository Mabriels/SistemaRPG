using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Repositorio;

namespace SistemaRPG.Services;

public class AutenticacaoServico
{
    private readonly UsuarioRepositorio _usuarioRepositorio;


    public AutenticacaoServico([FromServices] UsuarioRepositorio repositorio)
    {
        _usuarioRepositorio = repositorio;
    }



}
