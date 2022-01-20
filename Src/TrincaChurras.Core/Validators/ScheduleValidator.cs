using FluentValidation;
using System;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.Core.Validators
{
    public class ScheduleValidator : AbstractValidator<Schedule>
    {
        public ScheduleValidator()
        {
            RuleFor(x => x.Date)
               .NotEmpty()
               .WithMessage("Date is required");

            RuleFor(x => x.Date)
               .Must(ValidateDate)
               .WithMessage("The calendar date cannot be less than the current date");

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Description is required");

            RuleFor(x => x.SuggestedValueWithDrink)
               .NotNull()
               .WithMessage("SuggestedValueWithDrink is required");

            RuleFor(x => x.SuggestedValueWithoutDrink)
               .NotNull()
               .WithMessage("SuggestedValueWithoutDrink is required");

            RuleFor(x => x.IdUser)
              .NotEmpty()
              .WithMessage("IdUser is required");
        }

        public static bool ValidateDate(DateTime date)
        {
            return date.Date >= DateTime.Now.Date;
        }
    }
}
