using FluentValidation;

namespace CharityCalculator.Application.DTOs.Rate.Validators
{
    public class RateDtoValidator : AbstractValidator<RateDto>
    {
        public RateDtoValidator()
        {


            RuleFor(p => p.RateInPercentage)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
                .LessThanOrEqualTo(100).WithMessage("{PropertyName} must be less than or equal to 100.");

            RuleFor(p => p.RateType)
                .NotNull().WithMessage("{PropertyName} must not be null.");

        }
    }
}
