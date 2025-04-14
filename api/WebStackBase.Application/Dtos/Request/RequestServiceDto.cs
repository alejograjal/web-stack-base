namespace WebStackBase.Application.Dtos.Request;

public record RequestServiceDto : RequestBaseDto
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public bool IsEnabled { get; set; }
}