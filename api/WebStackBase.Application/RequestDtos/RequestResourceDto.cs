using WebStackBase.Application.RequestDTOs;

namespace WebStackBase.Application.RequestDtos;

public record RequestResourceDto : RequestBaseDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Path { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public long ResourceTypeId { get; set; }
}