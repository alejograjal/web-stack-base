using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStackBase.Domain.Core.Models;

namespace WebStackBase.Infrastructure;

[Table("Resource")]
public partial class Resource: BaseEntity
{
    public long ResourceTypeId { get; set; }

    [StringLength(80)]
    public string Name { get; set; } = null!;

    [StringLength(150)]
    public string Description { get; set; } = null!;

    [StringLength(100)]
    public string Url { get; set; } = null!;

    [StringLength(200)]
    public string Path { get; set; } = null!;

    public bool IsEnabled { get; set; }

    [ForeignKey("ResourceTypeId")]
    [InverseProperty("Resources")]
    public virtual ResourceType ResourceType { get; set; } = null!;

    [InverseProperty("Resource")]
    public virtual ICollection<ServiceResource> ServiceResources { get; set; } = new List<ServiceResource>();
}
