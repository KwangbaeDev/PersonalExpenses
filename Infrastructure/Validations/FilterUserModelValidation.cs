using System.Data;
using Core.Request;
using FluentValidation;

namespace Infrastructure.Validations;

public class FilterUserModelValidation : AbstractValidator<FilterUserModel>
{
    public FilterUserModelValidation()
    {
        RuleFor(x => x.PageIndex)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0)
            .WithMessage("The number entered must be greater than 0.");
    }
}