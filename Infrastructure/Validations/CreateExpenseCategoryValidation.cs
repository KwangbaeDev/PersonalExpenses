using Core.Request;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateExpenseCategoryValidation : AbstractValidator<CreateExpenseCategoryModel>
{
    public CreateExpenseCategoryValidation()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("Name cannot be null.")
            .NotEmpty()
            .WithMessage("Name cannot be empty.");


        RuleFor(x => x.Description)
            .NotNull()
            .WithMessage("Description cannot be null.")
            .NotEmpty()
            .WithMessage("Description cannot be empty.");


        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("UserId cannot be null.")
            .NotEmpty()
            .WithMessage("UserId cannot be empty.");
    }
}