using WebStackBase.Application.RequestDTOs;

namespace WebStackBase.Application.RequestDtos;

public record RequestServiceResourceDto : RequestBaseDto
{
    public long ServiceId { get; set; }

    public long ResourceId { get; set; }
}