using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("Review")]
public partial class Review : BaseSimpleEntity
{
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(150)]
    public string Email { get; set; } = null!;

    [StringLength(500)]
    public string Comment { get; set; } = null!;

    public byte Rate { get; set; }

    public DateTime Created { get; set; }

    public bool ShowInWeb { get; set; }
}
