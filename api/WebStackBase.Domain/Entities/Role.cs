using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("Role")]
public partial class Role: BaseEntity
{
    [StringLength(50)]
    public string Description { get; set; } = null!;

    [StringLength(50)]
    public string Type { get; set; } = null!;

    [InverseProperty("Role")]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
