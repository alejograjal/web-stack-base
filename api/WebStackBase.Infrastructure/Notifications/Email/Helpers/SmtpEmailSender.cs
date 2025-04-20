using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using WebStackBase.Application.Core.Models;
using WebStackBase.Application.Configuration;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Infrastructure.Notifications.Email.Helpers;

public class SmtpEmailSender : IEmailSender
{
    private readonly SmtpSettings _smtpSettings;

    public SmtpEmailSender(IOptions<SmtpSettings> smtpSettings) => _smtpSettings = smtpSettings.Value;

    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        using var client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
        {
            Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
            EnableSsl = _smtpSettings.EnableSsl
        };

        var mail = new MailMessage
        {
            From = new MailAddress(_smtpSettings.From, _smtpSettings.DisplayName),
            Subject = emailMessage.Subject,
            Body = emailMessage.Body,
            IsBodyHtml = emailMessage.IsHtml
        };

        mail.To.Add(emailMessage.To);

        await client.SendMailAsync(mail);
    }
}