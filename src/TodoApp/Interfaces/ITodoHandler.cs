using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITodoHandler
    {
        Task<ServiceResponse> CreateTodoItem(TodoModel model);
        //  Task CreateUser(UserModel model);
    }
}