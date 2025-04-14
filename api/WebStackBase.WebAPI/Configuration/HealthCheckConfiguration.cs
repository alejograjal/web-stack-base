using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Health check configuration
/// </summary>
public static class HealthCheckConfiguration
{
    /// <summary>
    /// Extension method to configure the health check
    /// </summary>
    /// <param name="services">Collection of services</param>
    public static void AddHealthChecksUIConfiguration(this IServiceCollection services)
    {
        services.AddHealthChecks();

        services.AddHealthChecksUI(setup =>
        {
            setup.SetEvaluationTimeInSeconds(15); // cada 15 seg
            setup.MaximumHistoryEntriesPerEndpoint(60);
            setup.AddHealthCheckEndpoint("API Health", "/health");
        });
    }

    /// <summary>
    /// Extension method to configure the health check
    /// </summary>
    /// <param name="app">Application builder</param>
    /// <returns> Application builder </returns>
    public static IApplicationBuilder UseHealthChecksUIConfiguration(this IApplicationBuilder app)
    {
        app.UseHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

        app.UseHealthChecksUI(config =>
        {
            config.UIPath = "/health-ui";
        });

        return app;
    }
}