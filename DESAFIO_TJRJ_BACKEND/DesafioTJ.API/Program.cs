using DesafioTJ.API.Authorization;
using DesafioTJ.API.Configuration;
using DesafioTJ.Domain.Interfaces.Repository;
using DesafioTJ.Domain.Interfaces.Service;
using DesafioTJ.Domain.Mapper;
using DesafioTJ.Domain.Service;
using DesafioTJ.Infra.Database;
using DesafioTJ.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextInjectionConfiguration(builder.Configuration.GetConnectionString("DbUsuarios"));
builder.Services.AddDependencyInjections();
builder.Services.AddAutoMapperApi(typeof(MapperProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDefinitions();

var app = builder.Build();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<BasicAuthMiddleware>();

app.MapControllers();

app.Run();
