using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.API.Enum;

namespace Services.Commands.Items
{
    public class CreateItemCommand 
    {
        public string Name { get; set; }
        
        public string Details { get; set; }
    
        public EnumItemStatus Status { get; set; }
    
        public int TodoId { get; set; }
    }
}
