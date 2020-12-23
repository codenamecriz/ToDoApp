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
        private readonly IMessageViewModel messageViewModel;
        public CreateTodoViewModel(IUnitOfWork _unitOfWork,  IMessageViewModel _messageViewModel)
        {
            messageViewModel = _messageViewModel;
            unitOfWork = _unitOfWork;
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
                                _message = result;

                            }
                            Close?.Invoke();  // Close windows

                        }
                        else { _message = "Please Fill up All TextBox!!"; }
                        messageViewModel.Message = _message;
                        MessageView todoview = new MessageView();

                        todoview.DataContext = messageViewModel;//appVM;
                        //Console.WriteLine(appVM.Message);
                        todoview.ShowDialog();

                    });
                }

                return _createTodoCommand;
            }
        }
        

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
