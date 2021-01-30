using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.Items
{
    public class GetItemQuery
    {
        public int Id { get; }
        public GetItemQuery(int id)
        {
            Id = id;
        }
    }
}
