using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("ServiceResource")]
public partial class ServiceResource : BaseSimpleEntity
{
    public long ServiceId { get; set; }

    public long ResourceId { get; set; }

    [ForeignKey("ResourceId")]
    [InverseProperty("ServiceResources")]
    public virtual Resource Resource { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("ServiceResources")]
    public virtual Service Service { get; set; } = null!;
}
