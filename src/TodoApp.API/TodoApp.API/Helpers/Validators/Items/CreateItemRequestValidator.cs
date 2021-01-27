using FluentValidation;
using Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators.Items
{
    public class CreateItemRequestValidator : AbstractValidator<CreateItemRequest>
    {
        public CreateItemRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.Details)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.Status.ToString())
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
        }
    }
}
