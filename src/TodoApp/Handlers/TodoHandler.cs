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
      try
      {
        var uniqueId = await _repository.GetHighestId().ConfigureAwait(false) + 1;
        var newItem = new TodoDataModel()
        {
          Id = uniqueId,
          Todo = model.Todo,
          Created = DateTime.UtcNow
        };

        await _repository.CreateTodoItem(newItem).ConfigureAwait(false);
        return new ServiceResponse
        {
          IsSuccessful = true,
          Message = "Successfully created todo item."
        };
      }
      catch (Exception e)
      {
        return new ServiceResponse
        {
          IsSuccessful = false,
          Message = e.StackTrace!
        };
      }
    }
  }
}