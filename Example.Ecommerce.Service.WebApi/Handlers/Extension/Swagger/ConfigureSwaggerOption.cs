using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Swagger
{
    public class ConfigureSwaggerOption : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        public ConfigureSwaggerOption(IApiVersionDescriptionProvider provider) => this.provider = provider;

        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (ApiVersionDescription description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
            }
        }

        private static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            OpenApiInfo info = new()
            {
                Version = description.ApiVersion.ToString(),
                Title = "Example company Services API Market",
                Description = "A simple example ASP.NET Core Web API.",
                TermsOfService = new("https://pacagroup.com/terms"),
                Contact = new()
                {
                    Name = "Jhon Eddier Solarte V.",
                    Email = "developjes@gmail.com",
                    Url = new("https://example.com/contact")
                },
                License = new()
                {
                    Name = "Use under LICX",
                    Url = new("https://example.com/licence")
                }
            };

            if (description.IsDeprecated)
            {
                info.Description = $"{info.Description} - Esta versión de la API ha quedado obsoleta.";
            }

            return info;
        }
    }
}
