using Microsoft.AspNetCore.Mvc;
using TodoApp.Data.Models;
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
        var response = await _handler.CreateTodoItem(model);
        if (!response.IsSuccessful)
        {
            return BadRequest(response.Message);
        }
        return Ok(response.Message);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteTodoRow(int id)
    {
        var response = await _handler.DeleteTodoRow(id).ConfigureAwait(false);
        if (!response.IsSuccessful)
        {
            return BadRequest(response.Message);
        }
        return Ok(response.Message);
    }

    [HttpGet("all-items")]
    public async Task<IEnumerable<TodoModel>> GetAllTodoItems()
    {
        var items = await _handler.GetAllTodoItems().ConfigureAwait(false);
        return items;
    }

    private readonly ILogger<TodoController> _logger;
    private readonly ITodoHandler _handler;
}
