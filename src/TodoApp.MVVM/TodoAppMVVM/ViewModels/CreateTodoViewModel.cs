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
using TodoApp.MVVM.Helpers.RequestApi;
using TodoApp.MVVM.IViewModels;
using TodoApp.MVVM.Models;
using TodoApp.MVVM.Models.ValueObject;
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
        private readonly IRequestApi _request;

        public CreateTodoViewModel(IUnitOfWork unitOfWork, IRequestApi request)
        {
            _unitOfWork = unitOfWork;
            _request = request;
        }

        #region Create/Update Button
        public ICommand CreateTodoButton
        {
            get
            {
                if (createTodoButton == null)
                {
                    createTodoButton = new RelayCommand(async () =>
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
                                //var result = _unitOfWork.CatchResult(_unitOfWork.TodoServices.Update(updateData));
                                
                                _request.TodoSendRequest.PutAsync(updateData);
                                Message = "Successfully Updated.!";

                            }
                            else
                            {
                                var AddData = new TodoListDTO
                                {
                                    Name = Name,
                                    Description = Description
                                };
                                //var result = _unitOfWork.CatchResult(_unitOfWork.TodoServices.Add(AddData));
                                var result = await _request.TodoSendRequest.PostAsync(AddData);

                                if (result.Error == true)
                                {
                                    Message = $"Error: Field Name: {result.FieldName}.  Error Message: {result.ErrorInformation}.";
                                }
                                else
                                {

                                    Message = "New Data Successfully Added.!";//result.ToString();
                                }

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
