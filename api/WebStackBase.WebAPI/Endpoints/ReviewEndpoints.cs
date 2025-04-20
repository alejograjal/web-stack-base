using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the review endpoints. 
    /// </summary>
    public static class ReviewEndpoints
    {
        /// <summary>
        /// Maps the review endpoints to the route builder. 
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapReviewEndpoints(this IEndpointRouteBuilder app)
        {

            var group = app.MapGroup("/api/review")
                       .WithTags("Review")
                       .RequireAuthorization("WebStackBase");

            group.MapGet("/", async ([FromServices] IServiceReview service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);
            })
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Get all review", "Retrieve all review"))
            .Produces<List<ResponseReviewDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapGet("/{id:long}", async ([FromServices] IServiceReview service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Get review by ID", "Retrieve a specific review based on the ID"))
            .Produces<ResponseReviewDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapPost("/", async ([FromServices] IServiceReview service, RequestReviewDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/review/{result.Id}", result);
            })
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Create review", "Create a new review"))
            .Produces<ResponseReviewDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapPut("/{id:long}", async ([FromServices] IServiceReview service, long id, RequestReviewDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithMetadata(new SwaggerOperationAttribute("Update review", "Update existing review"))
            .Produces<ResponseReviewDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}