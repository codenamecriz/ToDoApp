using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services.Queries.Items
{
    public interface IItemQueryService
    {
        Task<IEnumerable<Item>> GetTodoItemsByIdAsync(int id);
        Task<Item> GetItemByIdAsync(int id);

    }
}