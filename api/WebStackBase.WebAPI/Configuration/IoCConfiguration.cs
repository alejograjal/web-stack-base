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
    public static void ConfigureIoC(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.ConfigureGeneralServicesIoc();
        services.ConfigureApplication();
        services.ConfigureInfrastructureIoC();
    }
}