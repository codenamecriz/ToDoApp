using FluentValidation;
using Handlers.Commands;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.API.Helpers.Validators.Todos
{
    public class DeleteTodoRequestValidator : AbstractValidator<DeleteTodoRequest>
    {
        public DeleteTodoRequestValidator()
        {
            RuleFor(x => x.Id.ToString())
                .NotEmpty()
                .Matches("^[0-9]*$");
           

        }
    }
}
