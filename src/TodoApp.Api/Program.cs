using TodoApp.Api;
using TodoApp.Data.Interfaces;
using TodoApp.Data.Repositories;
using TodoApp.Handlers;
using TodoApp.Interfaces;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;

    // Add services to the container.
    services.AddSingleton<DbContext>();
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddScoped<ITodoHandler, TodoHandler>();
    services.AddScoped<ITodoRepository, TodoRepository>();

    services.AddSwaggerGen();
    
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
  }
}