using System.ComponentModel;

namespace WebStackBase.Application.Dtos.Response.Enums;

public enum RoleApplication
{
    [Description("Administrador")]
    ADMINISTRADOR = 1,

    [Description("Usuario")]
    USUARIO = 2,
}