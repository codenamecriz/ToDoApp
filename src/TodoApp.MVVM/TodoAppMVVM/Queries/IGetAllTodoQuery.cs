using System.Collections.Generic;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Queries
{
    public interface IGetAllTodoQuery
    {
        IEnumerable<Todo> GetAll();
    }
}