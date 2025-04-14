using FluentValidation;
using WebStackBase.Infrastructure;

namespace WebStackBase.Domain.Validations;

public class ReservationValidator : AbstractValidator<Reservation>
{
    public ReservationValidator()
    {
        RuleFor(x => x.CustomerName)
            .NotEmpty()
            .WithMessage("Customer name is required.")
            .Length(1, 100)
            .WithMessage("Customer name must be between 1 and 100 characters.");

        RuleFor(x => x.CustomerEmail)
            .NotEmpty()
            .WithMessage("Customer email is required.")
            .EmailAddress()
            .WithMessage("Customer email is not valid.")
            .Length(1, 150)
            .WithMessage("Customer email must be between 1 and 150 characters.");

        RuleFor(x => x.CustomerPhoneNumber)
            .NotEmpty()
            .WithMessage("Customer phone number is required.")
            .GreaterThan(0)
            .WithMessage("Customer phone number must be greater than 0.");

        RuleFor(x => x.Date)
            .NotEmpty()
            .WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Date cannot be in the future.");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("Comment is required.")
            .Length(1, 500)
            .WithMessage("Comment must be between 1 and 500 characters.");

        RuleFor(x => x.ReservationDetails)
            .NotNull()
            .WithMessage("Reservation details list cannot be null.")
            .NotEmpty()
            .WithMessage("Reservation cannot be added without details.");

        RuleForEach(x => x.ReservationDetails)
            .SetValidator(new ReservationDetailValidator());
    }
}