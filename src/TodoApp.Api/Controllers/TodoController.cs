using Microsoft.AspNetCore.Mvc;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Api.Controllers;

[ApiController]
[Route("api")]
public class TodoController : ControllerBase
{
    public TodoController(ILogger<TodoController> logger, ITodoHandler handler)
    {
        _logger = logger;
        _handler = handler;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTodoItem(TodoModel model)
    {
        var result = await _handler.CreateTodoItem(model);
        if (!result.IsSuccessful)
        {
            return BadRequest();
        }
        return Ok(result.Message);
    }

    private readonly ILogger<TodoController> _logger;
    private readonly ITodoHandler _handler;
}
