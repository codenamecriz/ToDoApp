using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Queries.Items
{
    public interface IItemQueryService
    {
        Task<IEnumerable<GetItemDto>> GetTodoItemsByIdAsync(GetItemQuery id);
        Task<GetItemDto> GetItemByIdAsync(GetItemQuery id);

    }
}