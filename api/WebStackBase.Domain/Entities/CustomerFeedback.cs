using WebStackBase.Domain.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebStackBase.Infrastructure;

[Table("CustomerFeedback")]
public partial class CustomerFeedback : BaseSimpleEntity
{
    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    [StringLength(150)]
    public string CustomerEmail { get; set; } = null!;

    [StringLength(500)]
    public string Comment { get; set; } = null!;

    public byte Rating { get; set; }

    public DateTime Created { get; set; }

    public bool ShowInWeb { get; set; }
}
