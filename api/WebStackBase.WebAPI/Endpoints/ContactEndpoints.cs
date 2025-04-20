using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints;

/// <summary>
/// This class contains the endpoints for contact-related operations.  
/// </summary>
public static class ContactEndpoints
{
    /// <summary>
    /// Maps the contact endpoints to the route builder.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    /// <returns>The endpoint route builder with the contact endpoints mapped.</returns>
    public static IEndpointRouteBuilder MapContactEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/contact")
                               .WithTags("Contact");

        group.MapPost("/", async ([FromServices] IServiceContact service, RequestContactDto request) =>
            {
                var result = await service.SendContactEmailAsync(request);
                return Results.Ok(result);
            })
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Create review", "Create a new review"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

        return app;
    }
}