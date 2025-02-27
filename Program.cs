using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o DbContext ao container de servi�os (ajuste a string de conex�o conforme necess�rio)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste a string de conex�o no appsettings.json

// Inje��o de depend�ncia para o reposit�rio
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

// Adicionando suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Mapeando os controllers
app.MapControllers();

// Iniciando a aplica��o
app.Run();
