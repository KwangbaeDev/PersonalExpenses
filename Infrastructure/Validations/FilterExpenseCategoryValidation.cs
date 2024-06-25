using Core.Request;
using FluentValidation;

namespace Infrastructure.Validations;

public class FilterExpenseCategoryValidation : AbstractValidator<FilterExpenseCategoryModel>
{
    public FilterExpenseCategoryValidation()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");
    }
}