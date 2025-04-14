using FluentValidation;
using FluentValidation.AspNetCore;
using WebStackBase.Application.Validations;
using WebStackBase.Application.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using WebStackBase.Application.Core.Interfaces;
using WebStackBase.Application.Services.Interfaces;
using WebStackBase.Application.Services.Implementations;
using WebStackBase.Application.Services.Interfaces.Authorization;
using WebStackBase.Application.Services.Implementations.Authorization;

namespace WebStackBase.Application.Configuration;

public static class Configuration
{
    public static void ConfigureGeneralServicesIoc(this IServiceCollection services)
    {
        services.AddScoped(typeof(ICoreService<>), typeof(CoreService<>));
    }

    /// <summary>
    /// Configure all elements of Application layer
    /// </summary>
    /// <param name="services">Service collection configuration</param>
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddScoped<IServiceCustomerFeedback, ServiceCustomerFeedback>();
        services.AddScoped<IServiceReservation, ServiceReservation>();
        services.AddScoped<IServiceResource, ServiceResource>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<IServiceServiceResource, ServiceServiceResource>();
        services.AddScoped<IServiceUser, ServiceUser>();

        services.AddScoped<IServiceUserContext, ServiceUserContext>();
        services.AddScoped<IServiceUserAuthorization, ServiceUserAuthorization>();
    }

    /// <summary>
    /// Add configuration for fluent validations
    /// </summary>
    /// <param name="services">Service collection</param>
    public static void ConfigureFluentValidation(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddValidatorsFromAssemblyContaining<ServiceValidator>();

        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
    }
}