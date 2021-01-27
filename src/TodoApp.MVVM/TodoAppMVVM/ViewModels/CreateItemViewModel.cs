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
using TodoApp.MVVM.Helpers.RequestApi;
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
        private readonly IRequestApi _request;
        public CreateItemViewModel(IUnitOfWork unitOfWork, IRequestApi request)
        {
            _unitOfWork = unitOfWork;
            _request = request;
        }
        #region Create/Update Button
        public ICommand CreateItemButton
        {
            get
            {
                if (createItemButton == null)
                {
                    createItemButton = new RelayCommand(async () =>
                    {
                        var Message = "";
                        if (ItemName.Trim().Length != 0 && ItemDetailed.Trim().Length != 0 && SelectStatus.Length != 0)
                        {
                            if (Id != 0)
                            {
                                var updateData = new Item
                                {
                                    Id = Id,
                                    Name = ItemName,
                                    Details = ItemDetailed,
                                    Status = SelectStatus
                                };
                                //Console.WriteLine(updateData.Id + "-" + updateData.Name + "-" + updateData.Details + "-" + updateData.Status);
                                //var result = _unitOfWork.CatchResult(_unitOfWork.ItemServices.Update(updateData));
                                var result = _request.ItemSendRequest.PutAsync(updateData);
                                Message = result.ToString();
                            }
                            else
                            {
                                var AddData = new Item
                                {
                                    Name = ItemName,
                                    Details = Detailed,
                                    Status = SelectStatus,
                                    TodoId = TodoId
                                };
                                //var result = _unitOfWork.CatchResult(_unitOfWork.ItemServices.Add(AddData));
                                var result = await _request.ItemSendRequest.PostAsync(AddData);
                                Message = result.ToString();

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
