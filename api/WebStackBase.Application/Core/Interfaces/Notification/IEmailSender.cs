using WebStackBase.Application.Core.Models;

namespace WebStackBase.Application.Core.Interfaces.Notification;

public interface IEmailSender
{
    Task SendEmailAsync(EmailMessage emailMessage);
}