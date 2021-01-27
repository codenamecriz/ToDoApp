using FluentValidation;
using Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators.Todos
{
    public class UpdateTodoRequestValidator : AbstractValidator<UpdateTodoRequest>
    {
        public UpdateTodoRequestValidator()
        {
            RuleFor(x => x.Id.ToString())
                .NotEmpty()
                .Matches("^[0-9]*$");
            RuleFor(x => x.TodoDataToUpdate.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.TodoDataToUpdate.Description)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");

        }
    }
}
