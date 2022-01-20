using FluentValidation;
using TrincaChurras.Core.Entities;

namespace TrincaChurras.Core.Validators
{
    public class ParticipantValidator : AbstractValidator<Participant>
    {
        public ParticipantValidator()
        {
            RuleFor(x => x.IdSchedule)
                .NotEmpty()
                .WithMessage("IdSchedule is required");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required");

            RuleFor(x => x.Value)
                .NotNull()
                .WithMessage("Value is required");
        }
    }
}
