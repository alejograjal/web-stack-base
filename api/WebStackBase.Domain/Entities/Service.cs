using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("Service")]
public partial class Service: BaseEntity
{
    [StringLength(80)]
    public string Name { get; set; } = null!;

    [StringLength(350)]
    public string Description { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Cost { get; set; }

    public bool IsEnabled { get; set; }

    [InverseProperty("Service")]
    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();

    [InverseProperty("Service")]
    public virtual ICollection<ServiceResource> ServiceResources { get; set; } = new List<ServiceResource>();
}
