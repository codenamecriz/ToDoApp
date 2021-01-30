using Services.Commands.Items.Request;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Commands.Items
{
    public interface IItemCommandService
    {
        Task<ResponseItemDto> CreateItemAsync(CreateItemCommand data);
        Task UpdateItemAsync(UpdateItemCommand data);
        Task DeleteItemAsync(DeleteItemCommand data);
    }
}