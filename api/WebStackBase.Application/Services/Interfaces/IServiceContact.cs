using WebStackBase.Application.Dtos.Request;

namespace WebStackBase.Application.Services.Interfaces;

public interface IServiceContact
{
    Task<bool> SendContactEmailAsync(RequestContactDto request);
}