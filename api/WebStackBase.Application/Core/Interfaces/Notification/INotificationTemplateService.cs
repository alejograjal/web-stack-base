using WebStackBase.Application.Dtos.Request;
using WebStackBase.Infrastructure;

namespace WebStackBase.Application.Core.Interfaces.Notification;

public interface INotificationTemplateService
{
    string GetReviewReceivedTemplate(Review review);

    string GetContactEmailTemplate(RequestContactDto emailMessage);
}