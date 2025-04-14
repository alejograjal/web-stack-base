using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebStackBase.Domain.Core.Models;

namespace WebStackBase.Infrastructure;

[Table("User")]
[Index("RoleId", Name = "IX_User_RoleId")]
public partial class User: BaseEntity
{
    [StringLength(50)]
    public string CardId { get; set; } = null!;

    [StringLength(80)]
    public string FirstName { get; set; } = null!;

    [StringLength(80)]
    public string LastName { get; set; } = null!;

    public int Telephone { get; set; }

    [StringLength(150)]
    public string Email { get; set; } = null!;

    [StringLength(80)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public long RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<TokenMaster> TokenMasters { get; set; } = new List<TokenMaster>();
}
