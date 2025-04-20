using Microsoft.Extensions.FileProviders;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Extension methods for configuring static files in the WebAPI project.
/// </summary>
public static class StaticFilesExtensions
{
    /// <summary>
    /// Configures static files for development environment.
    /// </summary>
    /// <param name="app">The WebApplication instance to configure.</param>
    /// <returns>The configured WebApplication instance.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown when the static file directory does not exist.</exception>
    public static IApplicationBuilder UseStaticFilesForDevelopment(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            var staticFilePath = Path.Combine(Directory.GetCurrentDirectory(), "api", "WebStackBase.WebAPI", "wwwroot", "gallery");

            if (!Directory.Exists(staticFilePath))
            {
                throw new DirectoryNotFoundException($"The static files folder is not located at the path: {staticFilePath}");
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilePath),
                RequestPath = "/gallery"
            });
        }

        return app;
    }
}