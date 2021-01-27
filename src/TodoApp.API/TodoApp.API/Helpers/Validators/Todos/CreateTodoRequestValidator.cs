using FluentValidation;
using Handlers;
using Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators
{
    public class CreateTodoRequestValidator : AbstractValidator<CreateTodoRequest>
    {
        public CreateTodoRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.Description)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");

        }
    }
}
