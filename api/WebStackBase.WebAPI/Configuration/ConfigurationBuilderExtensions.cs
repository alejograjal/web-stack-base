namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Configuration class for the IoC container
/// </summary>
public static class ConfigurationBuilderExtensions
{
    /// <summary>
    /// Extension method to add standard configuration sources
    /// </summary>
    /// <param name="builder">The <see cref="IConfigurationBuilder"/> to add the configuration sources to.</param>
    /// <returns>The <see cref="IConfigurationBuilder"/></returns>
    public static IConfigurationBuilder AddStandardConfiguration(this IConfigurationBuilder builder)
    {
        return builder
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .AddUserSecrets<Program>()
            .AddEnvironmentVariables();
    }
}