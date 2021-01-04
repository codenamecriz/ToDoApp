using Caliburn.Micro;
using Ninject;
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

namespace TodoAppMVVM.ViewModels
{
    public class CreateItemViewModel : VisibilityCommand, ICreateItemViewModel //VisibilityCommand
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoId { get; set; }
        private readonly IUnitOfWork unitOfWork;
        private readonly IMessageViewModel messageViewModel;
        public CreateItemViewModel(IUnitOfWork _unitOfWork, IMessageViewModel _messageViewModel)//, INinjectConfiguration _DI
        {
          
            unitOfWork = _unitOfWork;
            messageViewModel = _messageViewModel;
        }
        private ICommand _createItemCommand;

        public ICommand CreateItemCommand
        {
            get
            {
                if (_createItemCommand == null)
                {
                    _createItemCommand = new RelayCommand(() =>
                    {
                        var _message = "";
                        if (ItemName.Trim().Length != 0 && ItemDetailed.Trim().Length != 0 && SelectStatus.Length != 0)
                        {
                            if (Id != 0)
                            {
                                var data = new Item
                                {
                                    Id = Id,
                                    Name = ItemName,
                                    Detailed = ItemDetailed,
                                    Status = SelectStatus
                                };
                                Console.WriteLine(data.Id + "-" + data.Name + "-" + data.Detailed + "-" + data.Status);
                                var result = unitOfWork.catchResult(unitOfWork.ItemServices.Update(data));
                                _message = result;
                            }
                            else
                            {
                                var data = new Item
                                {
                                    Name = ItemName,
                                    Detailed = Detailed,
                                    Status = SelectStatus,
                                    TodoId = TodoId
                                };
                                //Console.WriteLine(data.TodoId+"<------");
                                var result = unitOfWork.catchResult(unitOfWork.ItemServices.Add(data));
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

                return _createItemCommand;
            }
        }
        
        public string ItemName
        {
            get
            {
                if (Name == null)
                { Name = ""; }
                return Name;
            }
            set { Name = value; }
        }

        public string ItemDetailed
        {
            get
            {
                if (Detailed == null)
                { Detailed = ""; }
                return Detailed;
            }
            set { Detailed = value; }
        }
        public string SelectStatus
        {
            get
            {
                if (Status == null)
                { Status = ""; }
                return Status;
            }
            set { Status = value; }
        }
    }
}
