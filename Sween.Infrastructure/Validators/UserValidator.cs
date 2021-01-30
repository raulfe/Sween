using FluentValidation;
using Sween.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sween.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name).NotNull().Length(1, 50);
        }
    }
}
