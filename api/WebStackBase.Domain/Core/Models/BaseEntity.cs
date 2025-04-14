using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Domain.Core.Models;

public class BaseEntity: BaseSimpleEntity
{
    [Column(TypeName = "datetime")]
    public DateTime Created { get; set; }

    [StringLength(70)]
    public string CreatedBy { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime? Updated { get; set; }

    [StringLength(70)]
    public string? UpdatedBy { get; set; }

    public bool IsActive { get; set; }        
}