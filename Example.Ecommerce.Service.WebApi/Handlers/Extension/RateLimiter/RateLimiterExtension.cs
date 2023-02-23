using Microsoft.AspNetCore.RateLimiting;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.RateLimiter
{
    public static class RateLimiterExtension
    {
        public static IServiceCollection AddRatelimiting(this IServiceCollection services, IConfiguration configuration)
        {
            const string fixedWindowPolicy = "fixedWindow";

            services.AddRateLimiter(configureOptions =>
            {
                configureOptions.AddFixedWindowLimiter(policyName: fixedWindowPolicy, fixedWindow =>
                {
                    fixedWindow.PermitLimit = int.Parse(configuration["RateLimiting:PermitLimit"]);
                    fixedWindow.Window = TimeSpan.FromSeconds(int.Parse(configuration["RateLimiting:Window"]));
                    fixedWindow.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                    fixedWindow.QueueLimit = int.Parse(configuration["RateLimiting:QueueLimit"]);
                });
                configureOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            });

            return services;
        }
    }
}
