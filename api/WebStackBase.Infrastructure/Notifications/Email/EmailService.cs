using WebStackBase.Domain.Exceptions;
using WebStackBase.Application.Core.Models;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Infrastructure.Notifications.Email;

public class EmailService : IEmailService
{
    private readonly INotificationTemplateService _notificationTemplateService;
    private readonly IEmailSender _emailSender;

    public EmailService(INotificationTemplateService notificationTemplateService, IEmailSender emailSender)
    {
        _notificationTemplateService = notificationTemplateService;
        _emailSender = emailSender;
    }

    public string EmailTo => "manuelantonioexplorer@gmail.com";

    /// <summary>
    /// Sends a contact email to the specified email address.
    /// </summary>
    /// <param name="emailMessage">The contact email message to be sent.</param>
    public Task SendContactEmailAsync(RequestContactDto emailMessage)
    {
        try
        {
            string emailBody = _notificationTemplateService.GetContactEmailTemplate(emailMessage);

            EmailMessage email = new EmailMessage
            {
                To = EmailTo,
                Subject = "New Contact Request",
                Body = emailBody
            };

            return _emailSender.SendEmailAsync(email);
        }
        catch
        {
            throw new WebStackBaseException("Error while sending email notification.");
        }

    }

    /// <summary>
    /// Sends a notification to the given email address.
    /// </summary>
    /// <param name="review">The review to send the notification for.</param>
    /// <returns>A task that completes when the notification is sent.</returns>
    public async Task SendReviewReceivedNotificationAsync(Review review)
    {
        try
        {
            string emailBody = _notificationTemplateService.GetReviewReceivedTemplate(review);

            EmailMessage email = new EmailMessage
            {
                To = EmailTo,
                Subject = "New Customer Feedback Received",
                Body = emailBody
            };

            await _emailSender.SendEmailAsync(email);
        }
        catch
        {
            throw new WebStackBaseException("Error while sending email notification.");
        }
    }
}