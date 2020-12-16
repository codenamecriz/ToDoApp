using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;
using TodoAppMVVM.Views;

namespace TodoAppMVVM.ViewModels
{
    public class CreateTodoViewModel 
    {
        private readonly UnitOfWork unitOfWork = new UnitOfWork();
        IWindowManager manager = new WindowManager();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public CreateTodoViewModel()//IUnitOfWork _unitOfWork)
        {
            //unitOfWork = _unitOfWork;
            //unitOfWork = new UnitOfWork();
        }



        public void Cancel()
        {

            //IWindowManager manager = new WindowManager();
            //manager.ShowWindow(new CreateTodoViewModel(), null, null);

            //CreateTodoView todoClose = new CreateTodoView();
            //todoClose.Close();
        }
        public void AddList()
        {
            //MessageViewModel msg = new MessageViewModel();
            //msg.Message = ListName;

            //manager.ShowWindow(msg);

            var data = new TodoModel
            {
                Name = Name,
                Description = Description,
            };
            var result = unitOfWork.catchResult(unitOfWork.ListServices.RegisterNewList(data));
            //MessageBox.Show(result);
        }
        //private string _msg = "this is a message ";
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
        public int TodoId
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
