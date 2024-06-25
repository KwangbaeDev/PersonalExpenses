using Core.Request.ExpenseModels;
using FluentValidation;

namespace Infrastructure.Validations;

public class FilterExpenseModelValidation : AbstractValidator<FilterExpenseModel>
{
    public FilterExpenseModelValidation()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(-1)
            .WithMessage("The expense amount cannot be negative.");


        RuleFor(x => x.PageIndex)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");
    }
}