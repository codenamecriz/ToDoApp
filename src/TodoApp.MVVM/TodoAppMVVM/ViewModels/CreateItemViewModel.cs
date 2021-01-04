using Caliburn.Micro;
using Ninject;
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

namespace TodoAppMVVM.ViewModels
{
    public class CreateItemViewModel : VisibilityCommand, ICreateItemViewModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoId { get; set; }

        private readonly IUnitOfWork _unitOfWork;
        public CreateItemViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #region Create/Update Button
        public ICommand CreateItemButton
        {
            get
            {
                if (createItemButton == null)
                {
                    createItemButton = new RelayCommand(() =>
                    {
                        var Message = "";
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
                                var result = _unitOfWork.CatchResult(_unitOfWork.ItemServices.Update(data));
                                Message = result;
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
                                var result = _unitOfWork.CatchResult(_unitOfWork.ItemServices.Add(data));
                                Message = result;

                            }
                            // Close windows
                            Close?.Invoke();  
                        }
                        else { Message = "Please Fill up All TextBox!!"; }

                        MessageBox.Show(Message);
                     
                    });
                }

                return createItemButton;
            }
        }
        #endregion

        #region UI Controls
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
        #endregion
    }
}
