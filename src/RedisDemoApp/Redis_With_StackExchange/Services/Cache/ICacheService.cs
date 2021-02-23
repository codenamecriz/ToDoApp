using Microsoft.Extensions.Caching.Distributed;
using Redis_With_StackExchange.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Redis_With_StackExchange.Services.Cache
{
    public interface ICacheService
    {

        Task SetObjectAsync<T>( string key, T value);

        Task<IEnumerable<T>> GetObjectAsync<T>( string key);
        Task<bool> ExistObjectAsync<T>( string key);
        void SaveRedisBigData(string key, string value);
        List<Item> ItemContainer();
    }
}