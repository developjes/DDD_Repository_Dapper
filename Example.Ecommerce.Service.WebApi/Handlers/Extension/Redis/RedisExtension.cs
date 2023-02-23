namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Redis
{
    public static class RedisExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
                options.Configuration = configuration.GetConnectionString("RedisConnection")
            );

            return services;
        }
    }
}
