namespace WebStackBase.Application.Core.Interfaces.Notification;

public interface IEmailTemplateService
{
    string LoadTemplate(string templateName);
}