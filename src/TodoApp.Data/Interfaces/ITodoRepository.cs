using TodoApp.Data.Data;

namespace TodoApp.Data.Interfaces
{
    public interface ITodoRepository
    {
        string CreateTodoItem(TodoItemDataModel model);
    }
}