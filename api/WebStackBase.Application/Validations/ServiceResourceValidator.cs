using FluentValidation;
using WebStackBase.Infrastructure;

namespace WebStackBase.Application.Validations;

public class ServiceResourceValidator : AbstractValidator<ServiceResource>
{
    public ServiceResourceValidator()
    {
        RuleFor(x => x.ServiceId)
            .GreaterThan(0)
            .WithMessage("You must specify a valid service.");

        RuleFor(x => x.ResourceId)
            .GreaterThan(0)
            .WithMessage("You must specify a valid resource.");
    }
}