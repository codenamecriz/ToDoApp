using Caliburn.Micro;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Cancel()
        {
            //IWindowManager manager = new WindowManager();
            //manager.ShowWindow(new CreateTodoViewModel(), null, null);
            
            //CreateTodoView todoClose = new CreateTodoView();
            //todoClose.Close();
        }
        private string _msg = "this is a message ";
        public string ListName
        {
            get { return Name; }
            set { Name = value; }
        }
       
        public string ListDescription
        {
            get { return Description; }
            set { Description = value; }
        }
    }
}
