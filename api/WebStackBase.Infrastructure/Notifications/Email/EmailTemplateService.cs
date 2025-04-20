using Microsoft.Extensions.Options;
using WebStackBase.Application.Configuration;
using WebStackBase.Application.Core.Interfaces.Notification;

namespace WebStackBase.Infrastructure.Notifications.Email.Helpers;

public class EmailTemplateService : IEmailTemplateService
{
    private readonly TemplateSettings _settings;

    public EmailTemplateService(IOptions<TemplateSettings> settings)
    {
        _settings = settings.Value;
    }

    public string LoadTemplate(string templateName)
    {
        var fullPath = Path.Combine(_settings.BasePath, templateName);

        if (!File.Exists(fullPath))
            throw new FileNotFoundException($"Email template not found: {fullPath}");

        return File.ReadAllText(fullPath);
    }
}