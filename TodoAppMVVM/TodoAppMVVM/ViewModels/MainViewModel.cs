using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Views;
using Caliburn.Micro;
using TodoAppMVVM.SQLite;

namespace TodoAppMVVM.ViewModels
{
    public class MainViewModel : Screen
    {
        private readonly DBContext createDb = new DBContext();
        public MainViewModel()
        {
            createDb.CreateDb();
        }
        public void Btn_CreateList() // Open Windows to Add Item Todo Data
        {
            CreateTodoView viewCtodo = new CreateTodoView();
            viewCtodo.ShowDialog();
            //ActivateItem(new CreateTodoViewModel());
        }
    }
    
}
