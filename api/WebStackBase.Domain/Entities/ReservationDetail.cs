using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("ReservationDetail")]
public partial class ReservationDetail: BaseSimpleEntity
{
    public long ReservationId { get; set; }

    public long ServiceId { get; set; }

    [ForeignKey("ReservationId")]
    [InverseProperty("ReservationDetails")]
    public virtual Reservation Reservation { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("ReservationDetails")]
    public virtual Service Service { get; set; } = null!;
}
