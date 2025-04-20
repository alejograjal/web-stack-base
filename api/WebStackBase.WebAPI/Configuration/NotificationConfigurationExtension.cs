using WebStackBase.Application.Configuration;
using WebStackBase.Infrastructure.Notifications.Email;
using WebStackBase.Application.Core.Interfaces.Notification;
using WebStackBase.Infrastructure.Notifications.Email.Helpers;
using WebStackBase.Infrastructure.Notifications;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Extension methods for configuring notification services. 
/// </summary>
public static class NotificationConfigurationExtension
{

    /// <summary>
    /// Configure all elements of Notification layer
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Configuration object</param>
    public static void ConfigureNotificationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
        services.AddSingleton<IEmailSender, SmtpEmailSender>();

        services.Configure<TemplateSettings>(configuration.GetSection("TemplateSettings"));
        services.AddSingleton<IEmailTemplateService, EmailTemplateService>();

        services.AddScoped<INotificationTemplateService, NotificationTemplateService>();
        services.AddScoped<IEmailService, EmailService>();
    }
}