using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseReviewDto : BaseSimpleEntity
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public byte Rate { get; set; }

    public DateTime Created { get; set; }

    public bool ShowInWeb { get; set; }
}