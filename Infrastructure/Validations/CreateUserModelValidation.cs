using System.Data;
using Core.Request;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Infrastructure.Validations;

public class CreateUserModelValidation : AbstractValidator<CreateUserModel>
{
    public CreateUserModelValidation()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null")
            .NotEmpty()
            .WithMessage("Name cannot be empty");

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("Email cannot be null")
            .NotEmpty()
            .WithMessage("Email cannot be empty");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Password cannot be null")
            .NotEmpty()
            .WithMessage("Password cannot be empty");
    }
}