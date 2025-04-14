using Serilog;
using WebStackBase.WebAPI.Swagger;
using WebStackBase.WebAPI.Endpoints;
using WebStackBase.WebAPI.Authorization;
using WebStackBase.WebAPI.Configuration;

var WebStackBaseSpecificOrigins = "_WebStackBaseSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


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

builder.Services.ConfigureIoC();

builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureFluentValidation();

builder.Services.ConfigureSwaggerAPI();

builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: WebStackBaseSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:44378",
                                             "http://localhost:5000",
                                             "https://localhost:44378",
                                             "https://localhost:5000",
                                             "https://localhost:5191",
                                             "http://localhost:5191",
                                             "http://localhost:5173",
                                             "https://localhost:5173")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

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

app.MapCustomerFeedbackEndpoints();
app.MapHealthCheckEndpoints();
app.MapReservationEndpoints();
app.MapResourceEndpoints();
app.MapServiceEndpoints();
app.MapServiceServiceResourceEndpoints();

await app.RunAsync();
