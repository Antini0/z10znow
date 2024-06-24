using Microsoft.EntityFrameworkCore;
using z10znow.Context;
using z10znow.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Dodaj rejestrację serwisu DbService
builder.Services.AddScoped<IDbService, DbService>();

builder.Services.AddDbContext<W7Context>(options => 
    options.UseSqlServer("Name=ConnectionStrings:Default"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

