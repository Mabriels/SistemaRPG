using Microsoft.EntityFrameworkCore;
using SistemaRPG.Data;
using SistemaRPG.Repositorio;
using SistemaRPG.Services;

var builder = WebApplication.CreateBuilder(args);

//Adicionando a minha classe de contexto na API
builder.Services.AddDbContext<ContextoBD>(
  options =>
  //Dizendo que vamos usar o MySQL
  options.UseMySql(
      //Pegando as configurações de acesso ao BD
      builder.Configuration.GetConnectionString("ConexaoBanco"),
      //Detectando o Servidor de BD
      ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ConexaoBanco"))
  )
);

// Add services to the container.

builder.Services.AddScoped<ClasseRepositorio>();
builder.Services.AddScoped<ClasseServico>();
builder.Services.AddScoped<RacaRepositorio>();
builder.Services.AddScoped<RacaServico>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<UsuarioServico>();
builder.Services.AddScoped<PersonagemRepositorio>();
builder.Services.AddScoped<PersonagemServico>();
builder.Services.AddScoped<EquipamentoRepositorio>();
builder.Services.AddScoped<EquipamentoServico>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
