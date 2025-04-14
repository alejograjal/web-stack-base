using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDtos;

public record ResponseCustomerFeedbackDto : BaseSimpleEntity
{
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public byte Rating { get; set; }

    public DateTime Created { get; set; }
}