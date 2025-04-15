using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseCustomerFeedbackDto : BaseSimpleEntity
{
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public byte Rating { get; set; }

    public DateTime Created { get; set; }

    public bool ShowInWeb { get; set; }
}