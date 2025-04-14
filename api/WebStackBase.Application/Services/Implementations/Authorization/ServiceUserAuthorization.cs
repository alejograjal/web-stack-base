using AutoMapper;
using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.ResponseDTOs;
using WebStackBase.Application.Services.Interfaces;
using WebStackBase.Application.Services.Interfaces.Authorization;

namespace WebStackBase.Application.Services.Implementations.Authorization;

public class ServiceUserAuthorization(IServiceUserContext serviceUserContext, IServiceUser serviceUser, IMapper mapper) : IServiceUserAuthorization
{
    /// <inheritdoc />
    public async Task<ResponseUserDto> GetLoggedUser()
    {
        var existingUser = await serviceUser.FindByEmailAsync(serviceUserContext.UserId!);
        var user = existingUser ?? throw new NotFoundException("User not found.");
        return mapper.Map<ResponseUserDto>(user);
    }
}