using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Commands.Items
{
    public interface IItemCommandService
    {
        Task<Item> CreateItemAsync(Item data);
        Task UpdateItemAsync(Item data);
        Task DeleteItemAsync(Item data);
    }
}