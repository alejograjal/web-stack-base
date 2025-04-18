using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebStackBase.Application.Dtos.Request;
using WebStackBase.Application.Dtos.Response;
using WebStackBase.Application.Services.Interfaces;

namespace WebStackBase.WebAPI.Endpoints
{
    /// <summary>
    /// Provides the customer feedback endpoints. 
    /// </summary>
    public static class CustomerFeedbackEndpoints
    {
        /// <summary>
        /// Maps the customer feedback endpoints to the route builder. 
        /// </summary>
        /// <param name="app">The endpoint route builder.</param>
        public static IEndpointRouteBuilder MapCustomerFeedbackEndpoints(this IEndpointRouteBuilder app)
        {

            var group = app.MapGroup("/api/feedback")
                       .WithTags("Customer Feedback")
                       .RequireAuthorization("WebStackBase");

            group.MapGet("/", async ([FromServices] IServiceCustomerFeedback service) =>
            {
                var result = await service.GetAllAsync();
                return Results.Ok(result);
            })
            .WithTags("Customer Feedback")
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Get all feedback", "Retrieve all customer feedback"))
            .Produces<List<ResponseCustomerFeedbackDto>>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapGet("/{id:long}", async ([FromServices] IServiceCustomerFeedback service, long id) =>
            {
                var result = await service.GetByIdAsync(id);
                return Results.Ok(result);
            })
            .WithTags("Customer Feedback")
            .WithMetadata(new SwaggerOperationAttribute("Get feedback by ID", "Retrieve a specific feedback based on the ID"))
            .Produces<ResponseCustomerFeedbackDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapPost("/", async ([FromServices] IServiceCustomerFeedback service, RequestCustomerFeedbackDto request) =>
            {
                var result = await service.CreateAsync(request);
                return Results.Created($"/api/feedback/{result.Id}", result);
            })
            .WithTags("Customer Feedback")
            .AllowAnonymous()
            .WithMetadata(new SwaggerOperationAttribute("Create feedback", "Create a new customer feedback"))
            .Produces<ResponseCustomerFeedbackDto>(StatusCodes.Status201Created)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            group.MapPut("/{id:long}", async ([FromServices] IServiceCustomerFeedback service, long id, RequestCustomerFeedbackDto request) =>
            {
                var result = await service.UpdateAsync(id, request);
                return Results.Ok(result);
            })
            .WithTags("Customer Feedback")
            .WithMetadata(new SwaggerOperationAttribute("Update feedback", "Update existing customer feedback"))
            .Produces<ResponseCustomerFeedbackDto>(StatusCodes.Status200OK)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status404NotFound)
            .Produces<ErrorDetailsWebStackBase>(StatusCodes.Status500InternalServerError);

            return app;
        }
    }
}