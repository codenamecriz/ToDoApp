using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Views;

namespace TodoAppMVVM.ViewModels
{
    public class CreateTodoViewModel
    {
        public void Cancel()
        {
            CreateTodoView todoClose = new CreateTodoView();
            todoClose.Close();
        }
    }
}
