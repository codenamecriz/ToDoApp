using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestCommands.RequestTodo;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestItem;
using TodoApp.MVVM.Helpers.RequestApi.RequestQueries.RequestTodo;

namespace TodoApp.MVVM.Helpers.RequestApi
{
    public interface IRequestApi
    {
        ITodoGetRequest TodoGetRequest { get; }
        ITodoSendRequest TodoSendRequest { get; }
        IItemGetRequest ItemGetRequest { get; }
        IItemSendRequest ItemSendRequest { get; }
    }
}