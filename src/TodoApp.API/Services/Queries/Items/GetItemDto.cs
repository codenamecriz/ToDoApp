using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.API.Enum;

namespace Services.Queries.Items
{
    public class GetItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Details { get; set; }

        public EnumItemStatus Status { get; set; }
    }
}
