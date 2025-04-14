using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("ResourceType")]
public partial class ResourceType: BaseSimpleEntity
{
    [StringLength(25)]
    public string Name { get; set; } = null!;

    [InverseProperty("ResourceType")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();
}
