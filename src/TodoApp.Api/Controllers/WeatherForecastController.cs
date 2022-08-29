using Microsoft.AspNetCore.Mvc;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("weather-forecast")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ITodoHandler _handler;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, ITodoHandler handler)
    {
        _logger = logger;
        _handler = handler;
    }

    [HttpGet("current")]
    public IActionResult Get()
    {
        var result = _handler.CreateTodo();
        if (!result.IsSuccessful)
        {
            return BadRequest();
        }
        return Ok(result.Message);
    }
}
