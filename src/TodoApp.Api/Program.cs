using System.Reflection;
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
    var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
    builder.Services.AddCors(options =>
    {
    options.AddPolicy(name: MyAllowSpecificOrigins,
      policy  =>
      {
        policy.WithOrigins("http://localhost:3000")
          .AllowAnyHeader()
          .AllowAnyMethod();
      });
    });

    var services = builder.Services;

    // Add services to the container.
    services.AddSingleton<DbContext>();
    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddScoped<ITodoHandler, TodoHandler>();
    services.AddScoped<ITodoRepository, TodoRepository>();

    services.AddSwaggerGen();
    builder.Configuration
      .AddEnvironmentVariables()
      .AddUserSecrets
      (
        Assembly.GetExecutingAssembly(), true
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
    app.UseCors(MyAllowSpecificOrigins);

    app.Run();
  }
}