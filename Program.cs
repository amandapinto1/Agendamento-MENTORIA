using Agendamento.Data;
using Agendamento.Data.Repositorios;
using Agendamento.Data.Repositorios.Interfaces;
using Agendamento.Services;
using Agendamento.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurando banco de dados
builder.Services.AddDbContext<AgendamentoContexto>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("AgendamentoDB")));

builder.Services.AddScoped<IServicoSala, ServicoSala>();
builder.Services.AddScoped<ISalaRepositorio, SalaRepositorio>();

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
