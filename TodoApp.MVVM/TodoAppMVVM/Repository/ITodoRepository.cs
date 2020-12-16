using System;
using System.Collections.Generic;
using System.Text;
using TodoAppMVVM.Models;

namespace TodoAppMVVM.Repository
{
    public interface ITodoRepository
    {

        //IEnumerable<TodoModel> GetAllDatalist();
        string Add(TodoModel datalist);
        string Update(TodoModel data);
        void Delete(int id);
    }
}
