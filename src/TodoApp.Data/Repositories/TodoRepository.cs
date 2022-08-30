using TodoApp.Data.Data;
using TodoApp.Data.Interfaces;
using TodoApp.Api;
using Dapper;

namespace TodoApp.Data.Repositories
{
  public class TodoRepository : ITodoRepository
  {
    public TodoRepository(DbContext db)
    {
      _db = db;
    }
    public async Task CreateTodoItem(TodoDataModel model)
    {
      using (var connection = _db.CreateConnection())
      {
        await connection.ExecuteAsync(@"
          INSERT INTO TodoItems
            (Id, Todo, Created) 
              VALUES
            (@Id, @Todo, @Created)",
            model).ConfigureAwait(false);
      }
    }

    public async Task<int> GetHighestId()
    {
      using (var connection = _db.CreateConnection())
      {
        return await connection.QueryFirstOrDefaultAsync<int>(@"
          SELECT Id FROM TodoItems 
          WHERE Id = (SELECT MAX(Id) FROM TodoItems)").ConfigureAwait(false);
      }
    }

    private readonly DbContext _db;
  }
}