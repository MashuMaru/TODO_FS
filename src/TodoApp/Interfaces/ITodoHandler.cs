using TodoApp.Models;

namespace TodoApp.Interfaces
{
    public interface ITodoHandler
    {
        ResponseModel CreateTodo();
        //  Task CreateUser(UserModel model);
    }
}