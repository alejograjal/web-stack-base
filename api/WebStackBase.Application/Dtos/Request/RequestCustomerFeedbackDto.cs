namespace WebStackBase.Application.Dtos.Request;

public record RequestCustomerFeedbackDto : RequestBaseDto
{
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public byte Rating { get; set; }

    public bool ShowInWeb { get; set; }
}