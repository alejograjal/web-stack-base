using Microsoft.Extensions.DependencyInjection;
using WebStackBase.Application.Core.Interfaces;

namespace WebStackBase.Infrastructure.Repositories;

/// <summary>
/// Configuration class for the infrastructure layer
/// </summary>
public static class Configuration
{
    /// <summary>
    /// Extension method to configure the infrastructure layer
    /// </summary>
    /// <param name="services">Collection of services</param>
    public static void ConfigureInfrastructureIoC(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}