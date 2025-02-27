using api_filmes_senai.Context;
using api_filmes_senai.Interfaces;
using api_filmes_senai.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o DbContext ao container de serviços (ajuste a string de conexão conforme necessário)
builder.Services.AddDbContext<Filmes_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Ajuste a string de conexão no appsettings.json

// Injeção de dependência para o repositório
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();

// Adicionando suporte para controllers
builder.Services.AddControllers();

var app = builder.Build();

// Mapeando os controllers
app.MapControllers();

// Iniciando a aplicação
app.Run();
