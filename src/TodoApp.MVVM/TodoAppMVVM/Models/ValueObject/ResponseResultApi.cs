using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.MVVM.Models.ValueObject
{
    public class ResponseResultApi
    {
        public bool Error { get; set; }
        public string TagName { get; set; }
        public string FieldName { get; set; }
        public string ErrorInformation { get; set; }

        public ItemDTO ItemContent { get; set; }
        public TodoListDTO TodoContent { get; set; }
    }


}
