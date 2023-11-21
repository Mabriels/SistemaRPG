using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SistemaRPG.Repositorio;
using Mapster;
using Microsoft.EntityFrameworkCore;
using SistemaRPG.DTOs.Usuario;
using SistemaRPG.Models;
using BCrypt;
using SistemaRPG.Exceptions;

namespace SistemaRPG.Services;

public class UsuarioServico
{
    private readonly UsuarioRepositorio _usuarioRepositorio;

    public UsuarioServico([FromServices] UsuarioRepositorio repositorio)
    {
        _usuarioRepositorio = repositorio;
    }

    public UsuarioResposta CriarUsuario(UsuarioCriarRequisicao novoUsuario)
    {
        //verificação de email
        var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(novoUsuario.Email);
        if(usuarioExistente is not null)
        {
           throw new Exception("Email já cadastrado!");
        }

        var usuario = novoUsuario.Adapt<Usuario>();

        //Criptografando senha
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);

        usuario = _usuarioRepositorio.CriarUsuario(usuario);

        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        return usuarioResposta;

    }

    public List<UsuarioResposta> ListarUsuarios()
    {
        return _usuarioRepositorio.ListarUsuarios().Adapt<List<UsuarioResposta>>();
    }

    public UsuarioResposta BuscarUsuarioPeloId(int id)
    { 
        return BuscarPeloId(id).Adapt<UsuarioResposta>();
    }

    public void RemoverUsuario(int id)
    {
        var usuario = BuscarPeloId(id);

        _usuarioRepositorio.RemoverUsuario(usuario);

    }

    public UsuarioResposta AtualizarUsuario(int id, UsuarioAtualizarRequisicao usuarioEditado)
    {
        var usuario = BuscarPeloId(id);

        //verificar se está alterando o email
        if(usuario.Email != usuarioEditado.Email)
        {
            var usuarioExistente = _usuarioRepositorio.BuscarUsuarioPeloEmail(usuarioEditado.Email);
            if(usuarioExistente is not null)
            {
                throw new EmailExistenteException();
            }
        }

        usuarioEditado.Adapt(usuario);

        _usuarioRepositorio.AtualizarUsuario();

        var usuarioResposta = usuario.Adapt<UsuarioResposta>();

        return usuarioResposta;
    }

    private Usuario BuscarPeloId(int id, bool tracking = true)
    {
        var usuario = _usuarioRepositorio.BuscarUsuarioPeloId(id, tracking);

        if(usuario is null)
        {
            throw new Exception("Usuario não encontrado!");
        }

        return usuario;
    }
}
