using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseServiceDto : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Cost { get; set; }

    public bool IsEnabled { get; set; }

    public virtual ICollection<ResponseReservationDetailDto> ReservationDetails { get; set; } = new List<ResponseReservationDetailDto>();

    public virtual ICollection<ResponseServiceResourceDto> ServiceResources { get; set; } = new List<ResponseServiceResourceDto>();
}