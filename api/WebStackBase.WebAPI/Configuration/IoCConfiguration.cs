using WebStackBase.Application.Configuration;
using WebStackBase.Infrastructure.Repositories;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Configuration class for the IoC container
/// </summary>
public static class IoCConfiguration
{
    /// <summary>
    /// Extension method to configure the IoC container
    /// </summary>
    /// <param name="services">Collection of services</param>
    /// <param name="configuration">Configuration settings</param>
    public static void ConfigureIoC(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.ConfigureGeneralServicesIoc();
        services.ConfigureApplication(configuration);
        services.ConfigureInfrastructureIoC();
    }
}