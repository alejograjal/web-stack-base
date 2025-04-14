namespace WebStackBase.WebAPI.Endpoints;

/// <summary>
/// Provides the health check endpoints.
/// </summary>
public static class HealthCheckEndpoints
{
    /// <summary>
    /// Maps the health check endpoints to the route builder.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public static IEndpointRouteBuilder MapHealthCheckEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapHealthChecks("/health");

        return app;
    }
}