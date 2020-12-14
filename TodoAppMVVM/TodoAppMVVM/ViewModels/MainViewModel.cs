using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Views;
using Caliburn.Micro;

namespace TodoAppMVVM.ViewModels
{
    public class MainViewModel : Screen
    {
      
        public void Btn_CreateList() // Open Windows to Add Item Todo Data
        {
            CreateTodoView viewCtodo = new CreateTodoView();
            viewCtodo.ShowDialog();
            //ActivateItem(new CreateTodoViewModel());
        }
    }
    
}
