using Microsoft.EntityFrameworkCore;
using SistemaRPG.Models;


namespace SistemaRPG.Data;

public class ContextoBD : DbContext
{
    public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
    {

    }

    //Tabelas
    public DbSet<Personagem> Personagens { get; set; }
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Raca> Racas { get; set; }
}
