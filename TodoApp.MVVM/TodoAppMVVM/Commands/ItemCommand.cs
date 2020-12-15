using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;

namespace TodoAppMVVM.Commands
{
    public class ItemCommand
    {
        private readonly IUnitOfWork unitOfWork;
        public ItemCommand(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public void Create(ItemModel data)
        {
            unitOfWork.catchResult(unitOfWork.ItemServices.RegisterNewItem(data));
        }
        public void Update(ItemModel data)
        {
            unitOfWork.catchResult(unitOfWork.ItemServices.UpdateItem(data));
        }
        public void Delete(ItemModel data)
        {
            unitOfWork.catchResult(unitOfWork.ItemServices.RemoveItem(data));
        }
    }
}
