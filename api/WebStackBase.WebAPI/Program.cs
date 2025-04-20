using Serilog;
using WebStackBase.WebAPI.Swagger;
using WebStackBase.WebAPI.Endpoints;
using Microsoft.AspNetCore.Http.Json;
using WebStackBase.WebAPI.Authorization;
using WebStackBase.WebAPI.Configuration;
using WebStackBase.Application.Configuration;

var WebStackBaseSpecificOrigins = "_WebStackBaseSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddStandardConfiguration();

builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("WebStackBase", p =>
    {
        p.RequireAuthenticatedUser();
        p.AddRequirements(new IdentifiedUser());
        p.Build();
    });
});

builder.Services.ConfigureDataBase(builder.Configuration);

builder.Services.ConfigureAuthentication(builder.Configuration);

builder.Services.ConfigureApiVersioning();

builder.Services.AddHttpContextAccessor();

builder.Services.ConfigureIoC(builder.Configuration);

builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureFluentValidation();

builder.Services.ConfigureSwaggerAPI();

builder.Services.ConfigureNotificationServices(builder.Configuration);

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: WebStackBaseSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

var app = builder.Build();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(WebStackBaseSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.LoadSwagger();

app.ConfigureExceptionHandler(Log.Logger);

app.MapControllers();

app.UseStaticFilesForDevelopment();

app.MapReviewEndpoints();
app.MapHealthCheckEndpoints();
app.MapReservationEndpoints();
app.MapResourceEndpoints();
app.MapServiceEndpoints();
app.MapServiceServiceResourceEndpoints();
app.MapContactEndpoints();

await app.RunAsync();
