using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.API.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TodoApp.API.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                //Console.WriteLine(errorsInModelState);
          
                var errorResponse = new ErrorResponse();

                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel
                        {
                            FieldName = error.Key,
                            Message = subError
                        };
                        Log.Warning("Error Found: in Field Name: {fieldname} -> Error_Information: {message}", errorModel.FieldName,errorModel.Message);
                 
                        errorResponse.Error.Add(errorModel);
                        
                        
                        //var result = JsonConvert.DeserializeObject<ErrorModel>(errorResponse);
                    }
                }
               
                context.Result = new BadRequestObjectResult(errorResponse);
                //string jsonString = JsonSerializer.Serialize(errorResponse);
                //Log.Warning("Error {fieldName}",errorResponse.Error);
                //Console.WriteLine("Error {fieldName}", errorResponse.Error);
                //Log.Warning(context.Result);
                return;
            }
            
            await next();
        }
    }
}
