using WebStackBase.Application.RequestDTOs;

namespace WebStackBase.Application.RequestDtos;

public record RequestReservationDetailDto : RequestBaseDto
{
    public long ReservationId { get; set; }

    public long ServiceId { get; set; }
}