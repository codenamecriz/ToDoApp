using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;

namespace TodoAppMVVM.Queries
{
    public class GetAllTodoQuery
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllTodoQuery(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IEnumerable<TodoModel> GetAll()
        {
            return unitOfWork.ListServices.LoadList();
        }
    }
}
