using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Services.Interfaces;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Application.Services.Implementations;

public class ServiceContact(IEmailService emailService) : IServiceContact
{
    public async Task<bool> SendContactEmailAsync(RequestContactDto request)
    {
        await emailService.SendContactEmailAsync(request);

        return true;
    }
}