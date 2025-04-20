using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Infrastructure.Notifications;

public class NotificationTemplateService : INotificationTemplateService
{
    private readonly IEmailTemplateService _templateService;

    public NotificationTemplateService(IEmailTemplateService templateService) => _templateService = templateService;

    public string GetContactEmailTemplate(RequestContactDto emailMessage)
    {
        string template = _templateService.LoadTemplate("ContactNotificationTemplate.html");

        template = template.Replace("{contact.Name}", emailMessage.Name)
                           .Replace("{contact.Email}", emailMessage.Email)
                           .Replace("{contact.Message}", emailMessage.Message);

        return template;
    }

    public string GetReviewReceivedTemplate(Review review)
    {
        string template = _templateService.LoadTemplate("ReviewReceivedTemplate.html");

        template = template.Replace("{review.Name}", review.Name)
                           .Replace("{review.Email}", review.Email)
                           .Replace("{review.Rate}", review.Rate.ToString())
                           .Replace("{review.Comment}", review.Comment)
                           .Replace("{starsSvg}", GenerateStarsSvg(review.Rate));

        return template;
    }

    private string GenerateStarsSvg(int rating)
    {
        return $"<svg xmlns='http://www.w3.org/2000/svg' width='100' height='20' viewBox='0 0 100 20'><g>{new string('★', rating).PadRight(5, '☆')}</g></svg>";
    }
}