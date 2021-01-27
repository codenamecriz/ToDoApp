using FluentValidation;
using Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators.Items
{
    public class DeleteItemRequestValidator : AbstractValidator<DeleteItemRequest>
    {
        public DeleteItemRequestValidator()
        {
            RuleFor(x => x.Id.ToString())
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            
        }
    }
}
