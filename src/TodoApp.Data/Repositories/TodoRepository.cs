using TodoApp.Data.Interfaces;
using TodoApp.Api;
using Dapper;
using TodoApp.Data.Models;

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
          (Id, Todo, Created, IsComplete) 
          VALUES
          (@Id, @Todo, @Created, @IsComplete)", model
        ).ConfigureAwait(false);
      }
    }

    public async Task<int> GetHighestId()
    {
      using (var connection = _db.CreateConnection())
      {
        return await connection.QueryFirstOrDefaultAsync<int>(@"
          SELECT Id FROM TodoItems 
          WHERE 
          Id = (SELECT MAX(ID) FROM TodoItems)"
        ).ConfigureAwait(false);
      }
    }

    public async Task DeleteTodoRow(int id)
    {
      using (var connection = _db.CreateConnection())
      {
        await connection.ExecuteAsync(@"
          DELETE FROM TodoItems 
          WHERE Id = @id", new { id }
        ).ConfigureAwait(false);
      }
    }

    public async Task<IEnumerable<TodoDataModel>> GetAllTodoItems()
    {
      using (var connection = _db.CreateConnection())
      {
        return await connection.QueryAsync<TodoDataModel>(@"
          SELECT Id, Todo, Created, IsComplete 
          FROM TodoItems"
        ).ConfigureAwait(false);
      }
    }

    public async Task SetTodoItemAsComplete(int id)
    {
      using (var connection = _db.CreateConnection())
      {
        await connection.ExecuteAsync(@"
          UPDATE TodoItems
          SET IsComplete = 1
          WHERE Id = @id", new { id }
        ).ConfigureAwait(false);
      }
    }

    private readonly DbContext _db;
  }
}