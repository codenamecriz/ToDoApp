using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.API.Enum;

namespace Services.Commands.Items.Request
{
    public class UpdateItemCommand : BaseCommand
    {
        
        public string Details { get; set; }

        public EnumItemStatus Status { get; set; }
    }
}
