using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.EventCommands;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;

namespace TodoAppMVVM.ViewModels
{
    public class CreateItemViewModel : VisibilityCommand
    {
        IWindowManager manager = new WindowManager();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Detailed { get; set; }
        public string Status { get; set; }
        private readonly UnitOfWork unitOfWork;
        public CreateItemViewModel()
        {
            unitOfWork = new UnitOfWork();
        }
        public void SaveButton()
        {
            
            
            MessageViewModel msg = new MessageViewModel();

            if (ItemName.Trim().Length != 0 && ItemDetailed.Trim().Length != 0)
            {
                if (Id != 0)
                {
                    var data = new ItemModel
                    {
                        TodoModelId = Id,
                        Name = ItemName,
                        Detailed = ItemDetailed,
                        Status = cbox_status,
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ItemServices.UpdateItem(data));
                    msg.Message = result;
                }
                else
                {
                    var data = new ItemModel
                    {
                     
                        Name = ItemName,
                        Detailed = Detailed,
                        Status = cbox_status,
                    };
                    var result = unitOfWork.catchResult(unitOfWork.ItemServices.RegisterNewItem(data));
                    msg.Message = result;

                }
                Close?.Invoke();  // Close windows

            }
            else { msg.Message = "Please Fill up All TextBox!!"; }
            manager.ShowWindow(msg);
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
        public string cbox_status
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
