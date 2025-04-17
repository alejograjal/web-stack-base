using Microsoft.EntityFrameworkCore;
using WebStackBase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Design;

namespace WebStackBase.WebAPI.Data;

/// <summary>
/// Design-time DbContext factory for creating instances of WebStackBaseContext.
/// This is used by EF Core tools during development.
/// It allows you to create a DbContext instance with a specific configuration
/// for design-time operations, such as migrations.
/// </summary>
public class ContextFactory : IDesignTimeDbContextFactory<WebStackBaseContext>
{
    /// <summary>
    /// Creates a new instance of the WebStackBaseContext using the provided arguments.
    /// </summary>
    /// <param name="args">
    /// The command-line arguments passed to the application.
    /// </param>
    /// <returns>A new instance of the WebStackBaseContext.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the connection string is null or empty.</exception>
    public WebStackBaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .AddUserSecrets<ContextFactory>()
        .Build();

        var connectionString = config.GetConnectionString("WebStackBase")
                             ?? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException("ConnectionString is null or empty");

        var optionsBuilder = new DbContextOptionsBuilder<WebStackBaseContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new WebStackBaseContext(optionsBuilder.Options);
    }
}