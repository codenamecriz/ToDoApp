using TodoApp.API.Models;

namespace Services
{
    public interface IDbAuthentication
    {
        int CheckingIfExist(Todo todo);
        int CheckingIfExist(Item todo);
    }
}