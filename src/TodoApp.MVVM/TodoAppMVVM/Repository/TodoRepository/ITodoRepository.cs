using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Repository
{
    public interface ITodoRepository
    {

        IEnumerable<Todo> GetAllDatalist();
        string Add(Todo datalist);
        string Update(Todo data);
        void RemoveList(int id);
    }
}
