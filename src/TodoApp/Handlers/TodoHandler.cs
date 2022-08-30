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
      var highestId = await _repository.GetHighestId().ConfigureAwait(false);

      var uniqueId = 0;
      if (highestId <= 0)
      {
        uniqueId = highestId + 1;
      }
      var newItem = new TodoDataModel()
      {
        Id = uniqueId,
        Todo = model.Todo,
        Created = DateTime.UtcNow
      };

      await _repository.CreateTodoItem(newItem).ConfigureAwait(false);

      var response = new ServiceResponse
      {
        IsSuccessful = true,
        Message = "Successfully created todo item."
      };

      return response;
    }
  }
}