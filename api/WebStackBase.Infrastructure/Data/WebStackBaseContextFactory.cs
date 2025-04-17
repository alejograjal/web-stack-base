using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;

namespace WebStackBase.Infrastructure.Data;

public class WebStackBaseContextFactory : IDesignTimeDbContextFactory<WebStackBaseContext>
{
    public WebStackBaseContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .AddUserSecrets<WebStackBaseContextFactory>()
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