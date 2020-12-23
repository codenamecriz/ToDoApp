using System.Collections.Generic;
using TodoApp.MVVM.Models;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Services
{
    public interface ITodoService
    {
        //List<string> catchResult(List<string> actionResult);
        //IEnumerable<Todo> LoadList();
        List<string> Add(Todo data);
        List<string> RemoveList(Todo data);
        List<string> Update(Todo data);
        void Save();
    }
}