using WebStackBase.Application.ResponseDTOs.Base;

namespace WebStackBase.Application.ResponseDTOs;

public record ResponseUserDto : BaseEntity
{
    public string CardId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Telephone { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly Birthday { get; set; }

    public string Password { get; set; } = null!;

    public string? ProfilePictureUrl { get; set; }

    public long RoleId { get; set; }

    public virtual ResponseRoleDto Role { get; set; } = null!;
}
