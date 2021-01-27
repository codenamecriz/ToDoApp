using RestSharp;

namespace TodoApp.MVVM.Helpers.RequestApi
{
    public interface IRequestConfig
    {
         RestClient ClientAddress();
        string TodoRoute();
        string TodoByIdRoute(int id);
        string ItemRoute();
        string ItemRoute(int id);
        string ItemPkIdRoute(int id);
    }
}