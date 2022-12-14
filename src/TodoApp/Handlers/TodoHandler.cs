using TodoApp.Data.Interfaces;
using TodoApp.Data.Models;
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

    public async Task<ServiceResponse> CreateTodoItem(TodoModel model)
    {
      try
      {
        var uniqueId = await _repository.GetHighestId().ConfigureAwait(false) + 1;
        var newItem = new TodoDataModel()
        {
          Id = uniqueId,
          Todo = model.Todo,
          Created = DateTime.UtcNow,
          IsComplete = false
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

    public async Task<ServiceResponse> DeleteTodoRow(int id)
    {
      try
      {
        await _repository.DeleteTodoRow(id).ConfigureAwait(false);
        return new ServiceResponse
        {
          IsSuccessful = true,
          Message = $"Successfully deleted {id} (id) from todo list."
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

    public async Task<IEnumerable<TodoModel>> GetAllTodoItems()
    {
      var items = await _repository.GetAllTodoItems().ConfigureAwait(false);
      
      var mappedItems = items
        .Select(x => new TodoModel()
        {
          Id = x.Id,
          Todo = x.Todo,
          Created = x.Created,
          IsComplete = x.IsComplete
        })
        .ToList();

      return mappedItems; 
    }

    public async Task<ServiceResponse> SetTodoItemAsComplete(int id)
    {
      try
      {
        await _repository.SetTodoItemAsComplete(id).ConfigureAwait(false);
        return new ServiceResponse
        {
          IsSuccessful = true,
          Message = $"Successfully set todo item {id} (id) to complete."
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

    private readonly ITodoRepository _repository;
  }
}