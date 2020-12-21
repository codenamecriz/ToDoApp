using Caliburn.Micro;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
        IWindowManager manager = new WindowManager();
        IKernel kernel;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoId { get; set; }
        private readonly IUnitOfWork unitOfWork;
        public CreateItemViewModel(IUnitOfWork _unitOfWork)
        {
            kernel = new StandardKernel();
            unitOfWork = _unitOfWork;
       
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
                        if (ItemName.Trim().Length != 0 && ItemDetailed.Trim().Length != 0)
                        {
                            if (Id != 0)
                            {
                                var data = new ItemModel
                                {
                                    ItemModelId = Id,
                                    Name = ItemName,
                                    Detailed = ItemDetailed,
                                    Status = SelectStatus
                                };
                                Console.WriteLine(data.ItemModelId + "-" + data.Name + "-" + data.Detailed + "-" + data.Status);
                                var result = unitOfWork.catchResult(unitOfWork.ItemServices.UpdateItem(data));
                                _message = result;
                            }
                            else
                            {
                                var data = new ItemModel
                                {
                                    Name = ItemName,
                                    Detailed = Detailed,
                                    Status = SelectStatus,
                                    TodoModelId = TodoId
                                };
                                var result = unitOfWork.catchResult(unitOfWork.ItemServices.RegisterNewItem(data));
                                _message = result;

                            }
                            Close?.Invoke();  // Close windows

                        }
                        else { _message = "Please Fill up All TextBox!!"; }
                        var appVM = kernel.Get<MessageViewModel>();
                        appVM.Message = _message;
                        MessageView todoview = new MessageView();

                        todoview.DataContext = appVM;
                        Console.WriteLine(appVM.Message);
                        todoview.ShowDialog();
                        //manager.ShowWindow(msg);

                    });
                }

                return _createItemCommand;
            }
        }
        //}
        //public void SaveButton()
        //{


        //    MessageViewModel msg = new MessageViewModel();

        //    if (ItemName.Trim().Length != 0 && ItemDetailed.Trim().Length != 0)
        //    {
        //        if (Id != 0)
        //        {
        //            var data = new ItemModel
        //            {
        //                ItemModelId = Id,
        //                Name = ItemName,
        //                Detailed = ItemDetailed,
        //                Status = SelectStatus
        //            };
        //            Console.WriteLine(data.ItemModelId + "-" + data.Name + "-" + data.Detailed + "-" + data.Status);
        //            var result = unitOfWork.catchResult(unitOfWork.ItemServices.UpdateItem(data));
        //            msg.Message = result;
        //        }
        //        else
        //        {
        //            var data = new ItemModel
        //            {

        //                Name = ItemName,
        //                Detailed = Detailed,
        //                Status = SelectStatus,
        //                TodoModelId = TodoId
        //            };
        //            var result = unitOfWork.catchResult(unitOfWork.ItemServices.RegisterNewItem(data));
        //            msg.Message = result;

        //        }
        //        Close?.Invoke();  // Close windows

        //    }
        //    else { msg.Message = "Please Fill up All TextBox!!"; }
        //    manager.ShowWindow(msg);
        //}
        //public int ItemId
        //{
        //    get
        //    {
        //        return Id;
        //    }
        //    set { Id = value; }
        //}
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
                return Status;
            }
            set { Status = value; }
        }
    }
}
