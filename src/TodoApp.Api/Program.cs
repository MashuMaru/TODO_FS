using System.Data;
using Microsoft.Data.SqlClient;
using TodoApp.Data.Interfaces;
using TodoApp.Data.Repositories;
using TodoApp.Handlers;
using TodoApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ITodoHandler, TodoHandler>();
builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection
    (

        builder.Configuration.GetConnectionString("DB:ConnectionString")
    )
);

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
