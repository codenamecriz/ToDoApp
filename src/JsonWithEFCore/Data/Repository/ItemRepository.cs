using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly DataContext _context ;
        public ItemRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<Item> GetAllItem()
        {
            return _context.Items;
        }
    }
}
