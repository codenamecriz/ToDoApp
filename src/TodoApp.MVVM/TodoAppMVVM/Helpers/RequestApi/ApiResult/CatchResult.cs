using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.MVVM.Models.ValueObject;

namespace TodoApp.MVVM.Helpers.RequestApi.ApiResult
{
    public class CatchResult
    {
        public ResponseResultApi ApiCatchResult( string resContent)
        {
            ResponseResultApi result = new ResponseResultApi();
            result.Error = false;

            var responseSplited1 = resContent.Split('{');
            var responseSplited2 = responseSplited1[2].Split('}');
            var responseSplited3 = responseSplited2[0].Split(',');
            var fieldName = responseSplited3[0].Split(':');
            var errorInfo = responseSplited3[1].Split(':');

            result.Error = true;
            result.TagName = "Todo";
            result.FieldName = fieldName[1];//fieldName[1],
            result.ErrorInformation = errorInfo[1];//errorInfo[1],
            result.TodoContent = null;
            result.ItemContent = null;
            return null;
        }
    }
}
