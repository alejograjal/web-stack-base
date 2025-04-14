using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebStackBase.WebAPI.Swagger;

/// <summary>
/// Operation filter to add api version header 
/// </summary>
public class DefaultApiVersionHeaderOperationFilter : IOperationFilter
{
    /// <summary>
    /// Apply  
    /// </summary>
    /// <param name="operation">Operation</param>
    /// <param name="context">Context</param>
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters ??= new List<OpenApiParameter>();

        operation.Parameters.Add(new OpenApiParameter
        {
            Name = "x-api-version",
            In = ParameterLocation.Header,
            Required = false,
            Schema = new OpenApiSchema
            {
                Type = "string",
                Default = new OpenApiString("1.0")
            }
        });
    }
}