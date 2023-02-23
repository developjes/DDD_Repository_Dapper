using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Authentication;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Converters;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Feature;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.HealthCheck;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Injection;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Mapper;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.RateLimiter;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Redis;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Swagger;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Validator;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Versioning;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.Watch;
using Example.Ecommerce.Service.WebApi.Handlers.Middleware;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using WatchDog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Antiforgery Cross-Site

builder.Services.AddAntiforgery(opts => opts.HeaderName = "X-XSRF-Token");

#endregion

builder.Services.AddControllers(x =>
{
    x.Filters.AddService(typeof(AntiforgeryCookieResultFilter));
    x.EnableEndpointRouting = false;
})
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

#region Feature

builder.Services.AddFeature(builder.Configuration);

#endregion

#region Authentication

builder.Services.AddAuthentication(builder.Configuration);

#endregion

#region Versioning

builder.Services.AddVersioning();

#endregion

#region Swagger

builder.Services.AddSwagger();

#endregion

#region Auto Mapper Configurations

builder.Services.AddMapper();

#endregion

#region Dependency Injection

builder.Services.AddInjection(builder.Configuration);

#endregion

#region Session

builder.Services.AddSession();

#endregion

#region Validator Input Dto

builder.Services.AddValidator();

#endregion

#region HealthCheck

builder.Services.AddHealthCheck(builder.Configuration);

#endregion

#region XLM support for input

builder.Services.AddControllers(options => options.RespectBrowserAcceptHeader = true)
    .AddXmlSerializerFormatters()
    .AddXmlDataContractSerializerFormatters();

#endregion

#region RateLimiting

builder.Services.AddRatelimiting(builder.Configuration);

#endregion

#region Monitoring

builder.Services.AddWatchDog(builder.Configuration);

#endregion

#region Redis

builder.Services.AddRedisCache(builder.Configuration);

#endregion

// Configure the HTTP request pipeline.

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // build a swagger endpoint for each discovered API version
        IApiVersionDescriptionProvider provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        for (int i = 0; i < provider.ApiVersionDescriptions.Count; i++)
        {
            ApiVersionDescription description = provider.ApiVersionDescriptions[i];
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }

        c.DisplayRequestDuration();
        c.ShowExtensions();
        c.ShowCommonExtensions();
        c.EnableValidator();
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(DocExpansion.List);
        c.InjectStylesheet("/css/SwaggerCustom.css");
    });
}

app.UseWatchDogExceptionLogger();

// Scan Headers: https://securityheaders.com/
app.UseMiddleware<SecurityHeadersMiddleware>();
// Global Exception
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.UseRequestLocalization();
app.UseSession();
app.MapControllers();

app.UseHealthChecksUI(config =>
{
    config.UIPath = "/hc-ui";
    config.AddCustomStylesheet("./wwwroot/css/dotnet.css");
});
app.MapHealthChecks("/health", new()
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
    AllowCachingResponses = false
});

app.UseWatchDog(conf => {
    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
});

app.Run();

public partial class Program { }