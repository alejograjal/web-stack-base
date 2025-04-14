using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the resource endpoints.
    /// </summary>
    public static class ResourceEndpoints
    {
        /// <summary>
        /// Maps the resource endpoints to the route builder.
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapResourceEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/resource")
                       .WithTags("Resource")
                       .RequireAuthorization("WebStackBase");

            // Get all resources
            group.MapGet("/", async ([FromServices] IServiceResource service, bool onlyEnabled = true) =>
            {
                var result = await service.GetAllAsync(onlyEnabled);
                return Results.Ok(result);
            })
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Get all resources", "Retrieve all resources"))
            .Produces<List<ResponseResourceDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Get resource by ID
            group.MapGet("/{id:long}", async ([FromServices] IServiceResource service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get resource by ID", "Retrieve a specific resource by ID"))
            .Produces<ResponseResourceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Create a new resource
            group.MapPost("/", async ([FromServices] IServiceResource service, RequestResourceDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/resource/{result.Id}", result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Create resource", "Create a new resource"))
            .Produces<ResponseResourceDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Update an existing resource
            group.MapPut("/{id:long}", async ([FromServices] IServiceResource service, long id, RequestResourceDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Update resource", "Update an existing resource"))
            .Produces<ResponseResourceDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Soft delete a resource (mark as inactive)
            group.MapDelete("/{id:long}", async ([FromServices] IServiceResource service, long id) =>
            {
                var result = await service.DeleteAsync(id);
                if (result)
                {
                    return Results.NoContent();
                }
                return Results.NotFound();
            })
            .WithMetadata(new SwaggerOperationAttribute("Delete resource", "Delete a resource by ID"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
