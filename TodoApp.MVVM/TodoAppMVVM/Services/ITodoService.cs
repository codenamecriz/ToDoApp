using System.Collections.Generic;

using TodoAppMVVM.Models;

namespace TodoAppMVVM.Services
{
    public interface ITodoService
    {
        //List<string> catchResult(List<string> actionResult);
        IEnumerable<TodoModel> LoadList();
       List<string> RegisterNewList(TodoModel data);
        List<string> RemoveList(TodoModel data);
        List<string> UpdateList(TodoModel data);
        void Save();
    }
}