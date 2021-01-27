using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.MVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestItem
{
    public interface IItemGetRequest
    {
        //Task<IEnumerable<ItemDTO>> GetAllItemAsync();

        Task<IEnumerable<ItemDTO>> GetItemByIdAsync(int id);

        Task<ItemDTO> GetItemByPkIdAsync(int id);
    }
}