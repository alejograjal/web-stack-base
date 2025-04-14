using FluentValidation;
using WebStackBase.Infrastructure;

namespace WebStackBase.Domain.Validations;

public class ResourceValidator : AbstractValidator<Resource>
{
    public ResourceValidator()
    {
        RuleFor(x => x.ResourceTypeId)
            .GreaterThan(0)
            .WithMessage("Resource type was not specified.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(80).WithMessage("Name cannot exceed 80 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(150).WithMessage("Description cannot exceed 150 characters.");

        RuleFor(x => x.Url)
            .NotEmpty().WithMessage("URL is required.")
            .MaximumLength(100).WithMessage("URL cannot exceed 100 characters.")
            .Must(uri => Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("URL is not in a valid format.");

        RuleFor(x => x.Path)
            .NotEmpty().WithMessage("Path is required.")
            .MaximumLength(200).WithMessage("Path cannot exceed 200 characters.");
    }
}