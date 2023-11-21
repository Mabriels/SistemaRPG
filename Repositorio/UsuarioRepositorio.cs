using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaRPG.Data;
using SistemaRPG.DTOs.Usuario;
using SistemaRPG.Models;

namespace SistemaRPG.Repositorio;

public class UsuarioRepositorio
{
    //Campo injetado
    private readonly ContextoBD _contexto;

    public UsuarioRepositorio([FromServices] ContextoBD contexto)
    {
        _contexto = contexto;
    }

    

    public Usuario CriarUsuario(Usuario usuario)
    {
        _contexto.Add(usuario);
        _contexto.SaveChanges();

        return usuario;
    }


    public Usuario BuscarUsuarioPeloEmail(string email)
    {
        return _contexto.Usuarios.AsNoTracking().FirstOrDefault(usuario => usuario.Email == email);
    }

    public List<Usuario> ListarUsuarios()
    {
        return _contexto.Usuarios.AsNoTracking().ToList();
    }

    public Usuario BuscarUsuarioPeloId(int id, bool tracking = true)
    {
        return tracking ?
        _contexto.Usuarios.FirstOrDefault(u => u.Id == id) :
        _contexto.Usuarios.AsNoTracking().FirstOrDefault(u => u.Id == id);
        
    }


    public void RemoverUsuario(Usuario usuario)
    {   
        _contexto.Remove(usuario);
        _contexto.SaveChanges();
    }

    public void AtualizarUsuario()
    {
        _contexto.SaveChanges();
    }
    
}
