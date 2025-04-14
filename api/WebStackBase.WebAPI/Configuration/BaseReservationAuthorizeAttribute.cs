using WebStackBase.Util;
using Microsoft.AspNetCore.Authorization;
using WebStackBase.Application.ResponseDTOs.Enums;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Authorization attribute for controllers
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class WebStackBaseAuthorizeAttribute : AuthorizeAttribute
{
    /// <summary>
    /// Default constructor
    /// </summary>
    /// <returns></returns>
    public WebStackBaseAuthorizeAttribute() : base() { }

    /// <summary>
    /// Overload constructor to pass list of roles
    /// </summary>
    /// <param name="roles">List of roles</param>
    public WebStackBaseAuthorizeAttribute(params RoleApplication[] roles)
    {
        var allowedRolesAsStrings = roles.Select(x => StringExtension.Capitalize(Enum.GetName(typeof(RoleApplication), x)!));
        Roles = string.Join(",", allowedRolesAsStrings);
    }
}