using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoAppMVVM.Models
{
    public class ItemModel
    {
        public int ItemModelId { get; set; } 
        public string Name { get; set; }

        public string Detailed { get; set; }
        public string Status { get; set; }
        public int TodoModelId { get; set; }


        public virtual TodoModel TodoModel { get; set; }
    }
}
