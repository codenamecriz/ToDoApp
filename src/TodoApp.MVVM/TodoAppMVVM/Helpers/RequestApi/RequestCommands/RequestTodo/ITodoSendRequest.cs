using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;
using TodoApp.MVVM.Models.ValueObject;
using TodoAppMVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestTodo
{
    public interface ITodoSendRequest
    {
        Task<ResponseResultApi> PostAsync(TodoListDTO data);

        void PutAsync(Todo data);

        Task<string> DeleteAsync(int id);
    }
}