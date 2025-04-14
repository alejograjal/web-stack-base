using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the service-resource assignment endpoints.
    /// </summary>
    public static class ServiceServiceResourceEndpoints
    {
        /// <summary>
        /// Maps the service-resource assignment endpoints to the route builder.
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapServiceServiceResourceEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/service-resource")
                       .WithTags("Service-Resource Assignment")
                       .RequireAuthorization("WebStackBase");

            // Create a service-resource assignment
            group.MapPost("/", async ([FromServices] IServiceServiceResource service, RequestServiceResourceDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/service-resource/{result.Id}", result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Create service-resource assignment", "Assign a resource to a service"))
            .Produces<ResponseServiceResourceDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Create multiple service-resource assignments
            group.MapPost("/bulk", async ([FromServices] IServiceServiceResource service, IEnumerable<RequestServiceResourceDto> request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Create multiple service-resource assignments", "Assign multiple resources to services"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Get all service-resource assignments by resource ID
            group.MapGet("/by-resource/{resourceId:long}", async ([FromServices] IServiceServiceResource service, long resourceId) =>
            {
                var result = await service.GetAllByResourceIdAsync(resourceId);
                return Results.Ok(result);
            })
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Get service-resource assignments by resource ID", "Retrieve all service-resource assignments by a given resource ID"))
            .Produces<List<ResponseServiceResourceDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Get a service-resource assignment by ID
            group.MapGet("/{id:long}", async ([FromServices] IServiceServiceResource service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get service-resource assignment by ID", "Retrieve a specific service-resource assignment by ID"))
            .Produces<ResponseServiceResourceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Update a service-resource assignment
            group.MapPut("/{id:long}", async ([FromServices] IServiceServiceResource service, long id, RequestServiceResourceDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Update service-resource assignment", "Update an existing service-resource assignment"))
            .Produces<ResponseServiceResourceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Delete a service-resource assignment
            group.MapDelete("/{id:long}", async ([FromServices] IServiceServiceResource service, long id) =>
            {
                var result = await service.DeleteAsync(id);
                if (result)
                {
                    return Results.NoContent();
                }
                return Results.NotFound();
            })
            .WithMetadata(new SwaggerOperationAttribute("Delete service-resource assignment", "Delete a service-resource assignment"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
