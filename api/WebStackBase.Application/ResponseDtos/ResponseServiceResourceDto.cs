using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDtos;

public record ResponseServiceResourceDto : BaseSimpleEntity
{
    public long ServiceId { get; set; }

    public long ResourceId { get; set; }

    public virtual ResponseResourceDto Resource { get; set; } = null!;
    
    public virtual ResponseServiceDto Service { get; set; } = null!;
}