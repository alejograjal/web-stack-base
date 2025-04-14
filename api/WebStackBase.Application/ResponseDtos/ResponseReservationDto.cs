using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDtos;

public record ResponseReservationDto : BaseEntity
{
    public string CustomerName { get; set; } = null!;

    public string CustomerEmail { get; set; } = null!;

    public long CustomerPhoneNumber { get; set; }

    public DateTime Date { get; set; }

    public string Comment { get; set; } = null!;

    public string Status { get; set; } = null!;

    public ICollection<ResponseReservationDetailDto> ReservationDetails { get; set; } = new List<ResponseReservationDetailDto>();
}