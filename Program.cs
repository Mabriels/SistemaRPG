using Microsoft.EntityFrameworkCore;
using SistemaRPG.Data;
using SistemaRPG.Repositorio;
using SistemaRPG.Services;

//Imports para a parte de autenticação
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// {
//   options.AddPolicy(name: MyAllowSpecificOrigins,
//                     policy =>
//                     {
//                       policy.WithOrigins("http://localhost:5173"); // add the allowed origins  
//                     });
// });

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
      policy =>
      {
        policy.WithOrigins("http://localhost:5266")
            .AllowAnyMethod()
            .AllowAnyHeader();
      });
});

// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         policy =>
//         {
//             policy.WithOrigins("http://example.com",
//                                 "http://www.contoso.com");
//         });
// });

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

//Configurações para usar Autenticação com JWT
var JWTChave = Encoding.ASCII.GetBytes(builder.Configuration["JWTChave"]);
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        IssuerSigningKey = new SymmetricSecurityKey(JWTChave),
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
      };
    });


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
builder.Services.AddScoped<AutenticacaoServico>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
