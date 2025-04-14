using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDtos;

public record ResponseResourceTypeDto : BaseSimpleEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<ResponseResourceDto> Resources { get; set; } = new List<ResponseResourceDto>();
}