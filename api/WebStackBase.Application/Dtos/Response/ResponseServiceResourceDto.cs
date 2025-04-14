using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseServiceResourceDto : BaseSimpleEntity
{
    public long ServiceId { get; set; }

    public long ResourceId { get; set; }

    public virtual ResponseResourceDto Resource { get; set; } = null!;

    public virtual ResponseServiceDto Service { get; set; } = null!;
}