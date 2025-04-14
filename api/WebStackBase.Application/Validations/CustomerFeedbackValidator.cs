using FluentValidation;
using WebStackBase.Infrastructure;

namespace WebStackBase.Application.Validations;

public class CustomerFeedbackValidator : AbstractValidator<CustomerFeedback>
{
    public CustomerFeedbackValidator()
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

        RuleFor(x => x.Comment)
            .NotEmpty()
            .WithMessage("Comment is required.")
            .Length(1, 500)
            .WithMessage("Comment must be between 1 and 500 characters.");

        RuleFor(x => x.Rating)
            .InclusiveBetween((byte)1, (byte)5)
            .WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.Created)
            .NotEmpty()
            .WithMessage("Creation date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Creation date cannot be in the future.");
    }
}