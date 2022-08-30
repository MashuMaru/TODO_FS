using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITodoHandler
    {
        Task<ServiceResponse> CreateTodoItem(TodoModel model);
        Task<ServiceResponse> DeleteTodoRow(int id);
        Task<IEnumerable<TodoModel>> GetAllTodoItems();
    }
}