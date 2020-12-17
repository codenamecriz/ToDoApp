using Caliburn.Micro;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;
using TodoAppMVVM.Views;
using Action = System.Action;

namespace TodoAppMVVM.ViewModels
{
    public class CreateTodoViewModel : ICloseWindows
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
        public void SaveButton()
        {
            
            MessageViewModel msg = new MessageViewModel();
            
            if (ListName.Trim().Length != 0 && ListDescription.Trim().Length != 0)
            {
                if (Id != 0)
                {
                    var data = new TodoModel
                    {
                        TodoModelId = Id,
                        Name = ListName,
                        Description = ListDescription,
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ListServices.UpdateList(data));
                    msg.Message = result;
                }
                else
                {
                    var data = new TodoModel
                    {
                        Name = Name,
                        Description = Description,
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ListServices.RegisterNewList(data));
                    msg.Message = result;

                }
                Close?.Invoke();
                
            }
            else { msg.Message = "Please Fill up All TextBox!!"; }
            manager.ShowWindow(msg);
        }
        //private string _msg = "this is a message ";
        
        public string ListName
        {
            get {
                if (Name == null)
                { Name = ""; }
                return Name; 
            }
            set { Name = value; }
        }

        public string ListDescription
        {
            get {
                if (Description == null)
                { Description = ""; }
                 return Description; 
            }
            set { Description = value; }
        }
        public int TodoId
        {
            get { return Id; }
            set { Id = value; }
        }

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand => _closeCommand ?? (_closeCommand = new DelegateCommand(CloseWindow));
        void CloseWindow()
        {
            Close?.Invoke();
        }
        public Action Close { get; set; }
    }
    interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
