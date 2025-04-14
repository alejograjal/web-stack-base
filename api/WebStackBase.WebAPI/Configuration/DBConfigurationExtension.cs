using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebStackBase.Infrastructure.Data;

namespace WebStackBase.WebAPI.Configuration;

/// <summary>
/// Database configuration extension class
/// </summary>
public static class DBConfigurationExtension
{
    /// <summary>
    /// Method in charge on configure the database context
    /// </summary>
    /// <param name="services">Service collection</param>
    /// <param name="configuration">Configuration settings</param>
    public static void ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        ArgumentNullException.ThrowIfNull(configuration.GetConnectionString("WebStackBase"));

        services.AddTransient<IDbConnection>(database => new SqlConnection(configuration.GetConnectionString("WebStackBase")));

        services.AddDbContext<WebStackBaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("WebStackBase"),
             sqlServerOption =>
             {
                 sqlServerOption.EnableRetryOnFailure();
             })
        );
    }
}