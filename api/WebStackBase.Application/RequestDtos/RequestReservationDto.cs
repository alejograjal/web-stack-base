using WebStackBase.Application.RequestDTOs;

namespace WebStackBase.Application.RequestDtos;

public record RequestReservationDto : RequestBaseDto
{
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public long CustomerPhoneNumber { get; set; }

    public DateTime Date { get; set; }

    public string Comment { get; set; } = null!;

    public string Status { get; set; } = null!;
}