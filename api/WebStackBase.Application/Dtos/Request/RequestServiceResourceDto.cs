namespace WebStackBase.Application.Dtos.Request;

public record RequestServiceResourceDto : RequestBaseDto
{
    public long ServiceId { get; set; }

    public long ResourceId { get; set; }
}