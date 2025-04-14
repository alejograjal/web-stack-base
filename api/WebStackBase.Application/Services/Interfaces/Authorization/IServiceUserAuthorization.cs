using WebStackBase.Application.Dtos.Response;

namespace WebStackBase.Application.Services.Interfaces.Authorization;

public interface IServiceUserAuthorization
{
    /// <summary>
    /// Get logged user from context jwt
    /// </summary>
    /// <returns>ResponseUsuarioDto</returns>
    Task<ResponseUserDto> GetLoggedUser();
}