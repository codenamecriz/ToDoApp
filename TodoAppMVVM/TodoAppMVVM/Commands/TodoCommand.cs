using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;

namespace TodoAppMVVM.Commands
{
    public class TodoCommand
    {
        private readonly IUnitOfWork unitOfWork;
        public TodoCommand(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public void Create(TodoModel data)
        {
            unitOfWork.catchResult(unitOfWork.ListServices.RegisterNewList(data));
        }
        public void Update(TodoModel data)
        { 
            unitOfWork.catchResult(unitOfWork.ListServices.UpdateList(data)); 
        }
        public void Delete(TodoModel data)
        { 
            unitOfWork.catchResult(unitOfWork.ListServices.RemoveList(data)); 
        }
    }
}
