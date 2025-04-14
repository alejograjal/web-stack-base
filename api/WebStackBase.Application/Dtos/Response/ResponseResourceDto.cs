using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseResourceDto : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Path { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public long ResourceTypeId { get; set; }

    public ResponseResourceTypeDto ResourceType { get; set; } = null!;

    public ICollection<ResponseServiceResourceDto> ServiceResources { get; set; } = new List<ResponseServiceResourceDto>();
}