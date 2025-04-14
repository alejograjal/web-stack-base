using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDtos;

public record ResponseReservationDetailDto : BaseSimpleEntity
{
    public long ReservationId { get; set; }

    public long ServiceId { get; set; }

    public ResponseReservationDto Reservation { get; set; } = null!;

    public ResponseServiceDto Service { get; set; } = null!;
}