using TodoApp.Data.Models;

namespace TodoApp.Data.Interfaces
{
    public interface ITodoRepository
    {
        Task CreateTodoItem(TodoDataModel model);
        Task<int> GetHighestId();
        Task DeleteTodoRow(int id);
        Task<IEnumerable<TodoDataModel>> GetAllTodoItems();
        Task SetTodoItemAsComplete(int id);
    }
}