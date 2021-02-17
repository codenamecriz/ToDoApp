using Domain.Entity;
using System.Collections;
using System.Collections.Generic;

namespace Data.Repository
{
    public interface IItemRepository
    {
        public IEnumerable<Item> GetAllItem();
    }
}