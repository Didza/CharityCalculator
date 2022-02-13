using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CharityCalculator.Application.DTOs.EventType.Validators
{
    public class EventTypeDtoValidator : AbstractValidator<EventTypeDto>
    {
        public EventTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.SupplementInPercentage)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.")
                .LessThanOrEqualTo(100).WithMessage("{PropertyName} must be less than or equal to 100.");

            RuleFor(p => p.MaximumDonationAmount)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to 0.");

        }
    }
}
