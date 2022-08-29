using TodoApp.Data.Data;
using TodoApp.Data.Interfaces;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Handlers
{
  public class TodoHandler : ITodoHandler
  {
    public TodoHandler(ITodoRepository repository)
    {
      _repository = repository;
    }
    private readonly ITodoRepository _repository;

    public ResponseModel CreateTodo()
    {
        var newItem = new TodoItemDataModel
        {
          Id = 1,
          Todo = "Make the connection to the repository.",
          Created = DateTime.UtcNow
        };

        _repository.CreateTodoItem(newItem);

        var response = new ResponseModel
        {
          IsSuccessful = true,
          Message = "Successfully linked"
        };

        return response;
    }
  }
}