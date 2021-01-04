using Caliburn.Micro;
using Ninject;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        private readonly IUnitOfWork _unitOfWork;
      
        public CreateTodoViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Create/Update Button
        public ICommand CreateTodoButton
        {
            get
            {
                if (createTodoButton == null)
                {
                    createTodoButton = new RelayCommand(() =>
                    {
                        var Message = "";
                        if (ListName.Trim().Length != 0 && ListDescription.Trim().Length != 0)
                        {
                            if (Id != 0)
                            {
                                var updateData = new Todo
                                {
                                    Id = Id,
                                    Name = ListName,
                                    Description = ListDescription,
                                };
                                var result = _unitOfWork.CatchResult(_unitOfWork.TodoServices.Update(updateData));
                                Message = result;

                            }
                            else
                            {
                                var AddData = new Todo
                                {
                                    Name = Name,
                                    Description = Description,
                                };
                                var result = _unitOfWork.CatchResult(_unitOfWork.TodoServices.Add(AddData));
                                Message = result;

                            }
                            Close?.Invoke();  // Close windows

                        }
                        else { Message = "Please Fill up All TextBox!!"; }
                   
                        MessageBox.Show(Message);

                    });
                }
                return createTodoButton;
            }
        }
        #endregion

        #region UI Controls
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
        #endregion

    }
}
