using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppMVVM.Models;
using TodoAppMVVM.Services;

namespace TodoAppMVVM.Queries
{
    public class GetAllItemQuery
    {
        private readonly IUnitOfWork unitOfWork;
        public GetAllItemQuery(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public IEnumerable<ItemModel> GetAllById(int id) //--------------------------------> Get All Itemm By Id
        {
            return unitOfWork.ItemServices.LoadItem(id);
        }
    }
}
