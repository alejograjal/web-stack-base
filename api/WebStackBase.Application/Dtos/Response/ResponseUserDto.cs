﻿using WebStackBase.Application.Dtos.Response.Base;

namespace WebStackBase.Application.Dtos.Response;

public record ResponseUserDto : BaseEntity
{
    public string CardId { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Telephone { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public long RoleId { get; set; }

    public ResponseRoleDto Role { get; set; } = null!;
}
