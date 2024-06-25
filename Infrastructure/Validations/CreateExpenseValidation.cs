using Core.Request.ExpenseModels;
using FluentValidation;

namespace Infrastructure.Validations;

public class CreateExpenseValidation : AbstractValidator<CreateExpenseModel>
{
    public CreateExpenseValidation()
    {
        RuleFor(x => x.Amount)
            .NotNull()
            .WithMessage("Amount cannot be null.")
            .NotEmpty()
            .WithMessage("Amount cannot be empty.")
            .GreaterThan(-1)
            .WithMessage("The expense amount cannot be negative.");
            

        RuleFor(x => x.ExpenseCategoryId)
            .NotNull()
            .WithMessage("ExpenseCategoryId cannot be null.")
            .NotEmpty()
            .WithMessage("ExpenseCategoryId cannot be empty.");
    }
}