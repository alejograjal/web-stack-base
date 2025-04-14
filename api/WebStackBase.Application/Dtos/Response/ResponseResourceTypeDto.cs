using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseResourceTypeDto : BaseSimpleEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<ResponseResourceDto> Resources { get; set; } = new List<ResponseResourceDto>();
}