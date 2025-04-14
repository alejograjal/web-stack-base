using FluentValidation;
using WebStackBase.Infrastructure;

namespace WebStackBase.Application.Validations;

public class ReservationDetailValidator : AbstractValidator<ReservationDetail>
{
    public ReservationDetailValidator()
    {
        RuleFor(x => x.ReservationId)
            .NotEqual(0)
            .WithMessage("Invalid reservation.");

        RuleFor(x => x.ServiceId)
            .NotEqual(0)
            .WithMessage("Invalid service.");
    }
}