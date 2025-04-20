namespace WebStackBase.Application.Dtos.Request;

public record RequestReviewDto : RequestBaseDto
{
    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public byte Rate { get; set; }

    public bool ShowInWeb { get; set; }
}