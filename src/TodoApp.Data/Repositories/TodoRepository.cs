using System.Data;
using TodoApp.Data.Data;
using TodoApp.Data.Interfaces;

namespace TodoApp.Data.Repositories
{
  public class TodoRepository : ITodoRepository
  {
    public TodoRepository(IDbConnection db)
    {
        _db = db;
    }
    private readonly IDbConnection _db;
    public string CreateTodoItem(TodoItemDataModel model)
    {
      var aString = model.ToString();
      return aString;
    }
  }
}