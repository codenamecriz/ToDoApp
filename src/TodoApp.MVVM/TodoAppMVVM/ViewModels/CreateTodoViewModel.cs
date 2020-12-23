using Caliburn.Micro;
using Ninject;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.MVVM;
using TodoApp.MVVM.Commands;
using TodoApp.MVVM.EventCommands;
using TodoApp.MVVM.IViewModels;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;
using TodoAppMVVM.Views;
using Action = System.Action;

namespace TodoAppMVVM.ViewModels
{
    public class CreateTodoViewModel : VisibilityCommand, ICreateTodoViewModel
    {
        private readonly IUnitOfWork unitOfWork;// = new UnitOfWork();
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //IKernel kernel;
        //private readonly INinjectConfiguration ninjectConfiguration;
        private readonly IMessageViewModel messageViewModel;
        public CreateTodoViewModel(IUnitOfWork _unitOfWork,  IMessageViewModel _messageViewModel)//INinjectConfiguration _DI,//, IKernel _kernel)//IUnitOfWork _unitOfWork)
        {
            messageViewModel = _messageViewModel;
            unitOfWork = _unitOfWork;
            //ninjectConfiguration = _DI;
            //unitOfWork = new UnitOfWork();
            //kernel = _kernel;//new StandardKernel();

        }

        private ICommand _createTodoCommand;

        public ICommand CreateTodoCommand
        {
            get
            {
                if (_createTodoCommand == null)
                {
                    _createTodoCommand = new RelayCommand(() =>
                    {
                        //MessageViewModel msg = new MessageViewModel();
                        var _message = "";
                        if (ListName.Trim().Length != 0 && ListDescription.Trim().Length != 0)
                        {
                            if (Id != 0)
                            {
                                var data = new Todo
                                {
                                    Id = Id,
                                    Name = ListName,
                                    Description = ListDescription,
                                };
                                var result = unitOfWork.catchResult(unitOfWork.TodoServices.Update(data));
                                //msg.Message = result;
                                _message = result;

                            }
                            else
                            {
                                var data = new Todo
                                {
                                    Name = Name,
                                    Description = Description,
                                };
                                var result = unitOfWork.catchResult(unitOfWork.TodoServices.Add(data));
                                //msg.Message = result;
                                _message = result;

                            }
                            Close?.Invoke();  // Close windows

                        }
                        else { _message = "Please Fill up All TextBox!!"; }
                        //var appVM = ninjectConfiguration.Configure().Get<MessageViewModel>();

                        //appVM.Message = _message;
                        messageViewModel.Message = _message;
                        MessageView todoview = new MessageView();

                        todoview.DataContext = messageViewModel;//appVM;
                        //Console.WriteLine(appVM.Message);
                        todoview.ShowDialog();
                        //manager.ShowWindow(msg);

                    });
                }

                return _createTodoCommand;
            }
        }
        //public void SaveButton()
        //{

        //    MessageViewModel msg = new MessageViewModel();

        //    if (ListName.Trim().Length != 0 && ListDescription.Trim().Length != 0)
        //    {
        //        if (Id != 0)
        //        {
        //            var data = new TodoModel
        //            {
        //                TodoModelId = Id,
        //                Name = ListName,
        //                Description = ListDescription,
        //            };
        //            var result = unitOfWork.catchResult(unitOfWork.ListServices.UpdateList(data));
        //            msg.Message = result;

        //        }
        //        else
        //        {
        //            var data = new TodoModel
        //            {
        //                Name = Name,
        //                Description = Description,
        //            };
        //            var result = unitOfWork.catchResult(unitOfWork.ListServices.RegisterNewList(data));
        //            msg.Message = result;

        //        }
        //        Close?.Invoke();  // Close windows

        //    }
        //    else { msg.Message = "Please Fill up All TextBox!!"; }
        //    manager.ShowWindow(msg);
        //}
        //private string _msg = "this is a message ";

        public string ListName
        {
            get
            {
                if (Name == null)
                { Name = ""; }
                return Name;
            }
            set { Name = value; }
        }

        public string ListDescription
        {
            get
            {
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

    }
}
