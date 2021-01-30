using Services.Commands.Items;
using Services.Commands.Items.Request;
using System.Threading.Tasks;
using TodoApp.API.Models;

namespace Services
{
    public interface IDbAuthentication
    {
        Task<int> CheckingIfExist(Todo todo);
        Task<int> CheckingIfExist(BaseCommand data);
    }
}