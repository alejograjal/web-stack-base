using WebStackBase.Application.Dtos.Response.Enums;

namespace WebStackBase.Application.Dtos.Response.Authentication;

public record CurrentUser
{
    public long UserId { get; init; }

    public string? Email { get; init; }

    public RoleApplication? Role { get; init; }
}