using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.Models
{
    public class Item
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoId { get; set; }


        public virtual Todo TodoModel { get; set; }
    }
}
