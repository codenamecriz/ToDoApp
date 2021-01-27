using System.Threading.Tasks;
using TodoAppMVVM.Models;

namespace TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestItem
{
    public interface IItemSendRequest
    {
        Task<string> PostAsync(Item data);

        Task<string> PutAsync(Item data);

        Task<string> DeleteAsync(int id);
    }
}