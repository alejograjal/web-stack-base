using WebStackBase.Infrastructure;
using WebStackBase.Application.Dtos.Request;

namespace WebStackBase.Application.Core.Interfaces.Notification;

public interface IEmailService
{
    string EmailTo { get; }

    Task SendReviewReceivedNotificationAsync(Review review);

    Task SendContactEmailAsync(RequestContactDto emailMessage);
}