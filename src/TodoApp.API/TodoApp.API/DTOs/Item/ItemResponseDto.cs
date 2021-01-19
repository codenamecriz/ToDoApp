using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Enum;
using static TodoApp.API.Enum.EnumItemStatus;

namespace TodoApp.API.DTOs.Item
{
    public class ItemResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public EnumItemStatus Status { get; set; }
        //private ItemStatus status;
        //public EnumItemStatus Status 
        //{
        //    get;set;
        //    //get { return Status.ToString(); }
        //    //set 
        //    //{
        //    //    //status = Enum(typeof(ItemStatus), enumValue);
        //    //    //if (Status == 1)
        //    //    //{ }
        //    //}
        //}
    }
}
