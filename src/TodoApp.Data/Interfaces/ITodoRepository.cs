using System.Data;
using TodoApp.Data.Data;

namespace TodoApp.Data.Interfaces
{
    public interface ITodoRepository
    {
        Task CreateTodoItem(TodoDataModel model);
        Task<int> GetHighestId();
        Task DeleteTodoRow(int id);
    }
}