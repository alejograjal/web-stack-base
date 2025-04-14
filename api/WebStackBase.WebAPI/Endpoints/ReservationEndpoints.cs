using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.RequestDtos;
using WebStackBase.Application.ResponseDtos;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the reservation endpoints.
    /// </summary>
    public static class ReservationEndpoints
    {
        /// <summary>
        /// Maps the reservation endpoints to the route builder.
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapReservationEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/reservation")
                       .WithTags("Reservation")
                       .RequireAuthorization("WebStackBase");

            // Get all reservations
            group.MapGet("/", async ([FromServices] IServiceReservation service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get all reservations", "Retrieve all reservations"))
            .Produces<List<ResponseReservationDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Get reservation by ID
            group.MapGet("/{id:long}", async ([FromServices] IServiceReservation service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get reservation by ID", "Retrieve a specific reservation by ID"))
            .Produces<ResponseReservationDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Create a new reservation
            group.MapPost("/", async ([FromServices] IServiceReservation service, RequestReservationDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/reservation/{result.Id}", result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Create reservation", "Create a new reservation"))
            .Produces<ResponseReservationDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Update an existing reservation
            group.MapPut("/{id:long}", async ([FromServices] IServiceReservation service, long id, RequestReservationDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Update reservation", "Update an existing reservation"))
            .Produces<ResponseReservationDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            // Delete reservation (if you need this functionality)
            group.MapDelete("/{id:long}", async ([FromServices] IServiceReservation service, long id) =>
            {
                var result = await service.DeleteAsync(id);
                if (result)
                {
                    return Results.NoContent();
                }
                return Results.NotFound();
            })
            .WithMetadata(new SwaggerOperationAttribute("Delete reservation", "Delete a reservation by ID"))
            .Produces<bool>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}
