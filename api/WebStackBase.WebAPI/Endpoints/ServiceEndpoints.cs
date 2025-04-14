using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the service endpoints.
    /// </summary>
    public static class ServiceEndpoints
    {
        /// <summary>
        /// Maps the service endpoints to the route builder.
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapServiceEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/service")
                       .WithTags("Service")
                       .RequireAuthorization("WebStackBase");

            // Get all services
            group.MapGet("/", async ([FromServices] IServiceService service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get all services", "Retrieve all services"))
            .Produces<List<ResponseServiceDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Get service by ID
            group.MapGet("/{id:long}", async ([FromServices] IServiceService service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get service by ID", "Retrieve a specific service by ID"))
            .Produces<ResponseServiceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Create a new service
            group.MapPost("/", async ([FromServices] IServiceService service, RequestServiceDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/service/{result.Id}", result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Create service", "Create a new service"))
            .Produces<ResponseServiceDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Update an existing service
            group.MapPut("/{id:long}", async ([FromServices] IServiceService service, long id, RequestServiceDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Update service", "Update an existing service"))
            .Produces<ResponseServiceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Soft delete a service (mark as inactive)
            group.MapDelete("/{id:long}", async ([FromServices] IServiceService service, long id) =>
            {
                var result = await service.DeleteAsync(id);
                if (result)
                {
                    return Results.NoContent();
                }
                return Results.NotFound();
            })
            .WithMetadata(new SwaggerOperationAttribute("Delete service", "Delete a service by ID"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
