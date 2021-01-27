using FluentValidation;
using Handlers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators.Items
{
    public class UpdateItemRequestValidator : AbstractValidator<UpdateItemRequest>
    {
        public UpdateItemRequestValidator()
        {
            RuleFor(x => x.Id.ToString())
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.ItemToUpdate.Details)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
            RuleFor(x => x.ItemToUpdate.Status.ToString())
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");

        }
    }
}
