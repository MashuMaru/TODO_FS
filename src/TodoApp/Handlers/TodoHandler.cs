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

    public async Task<ServiceResponse> CreateTodoItem(TodoModel model)
    {
        var newItem = new TodoDataModel()
        {
          Id = 1,
          Todo = model.Todo,
          Created = DateTime.UtcNow
        };

        await _repository.CreateTodoItem(newItem).ConfigureAwait(false);

        var response = new ServiceResponse
        {
          IsSuccessful = true,
          Message = "Successfully linked"
        };

        return response;
    }
  }
}