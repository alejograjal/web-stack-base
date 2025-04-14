using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseReservationDetailDto : BaseSimpleEntity
{
    public long ReservationId { get; set; }

    public long ServiceId { get; set; }

    public ResponseReservationDto Reservation { get; set; } = null!;

    public ResponseServiceDto Service { get; set; } = null!;
}