using Microsoft.EntityFrameworkCore;
using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("Reservation")]
public partial class Reservation: BaseSimpleEntity
{
    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    [StringLength(150)]
    public string CustomerEmail { get; set; } = null!;

    public long CustomerPhoneNumber { get; set; }

    public DateTime Date { get; set; }

    [StringLength(300)]
    public string Comment { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [InverseProperty("Reservation")]
    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
