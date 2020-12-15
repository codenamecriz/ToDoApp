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
        IWindowManager manager = new WindowManager();
        private readonly DBContext createDb = new DBContext();
        public MainViewModel()
        {
            createDb.CreateDb();
        }
        public void Btn_CreateList() // Open Windows to Add Item Todo Data
        {
            //CreateTodoView viewCtodo = new CreateTodoView();
            //viewCtodo.ShowDialog();
            //DisplayRootViewFor<MessageViewModel>();
            CreateTodoViewModel TodoWindow = new CreateTodoViewModel();
            TodoWindow.Id = 1;
            TodoWindow.Name = "name";
            TodoWindow.Description = "Description";
            manager.ShowWindow(TodoWindow);
            //manager.ShowWindow(new CreateTodoViewModel(), null, null);

            //MessageView viewCtodo = new MessageView();
            //viewCtodo.ShowDialog();

        }
        private string msg = "this is message";
        public string Labelmsg
        {
            get { return msg; }
            set { msg = value; }
        }
    }
    
}
