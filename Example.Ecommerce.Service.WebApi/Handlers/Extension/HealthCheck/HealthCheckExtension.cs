namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.HealthCheck
{
    public static class HealthCheckExtension
    {
        public static IServiceCollection AddHealthCheck(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddSqlServer(
                    connectionString: configuration.GetConnectionString("NorthwindConnection")!,
                    healthQuery: "SELECT 1;",
                    name: "SQL Server",
                    tags: new string[] { "database" }
                 )
                .AddRedis(
                    redisConnectionString: configuration.GetConnectionString("RedisConnection")!,
                    name: "Redis DB",
                    tags: new[] { "cache" }
                )
                .AddCheck<HealthCheckCustom>(
                    name: "Google Ip",
                    tags: new[] { "ping" }
                )
                ;
            services.AddHealthChecksUI(setupSettings: setup =>
            {
                setup.SetEvaluationTimeInSeconds(int.Parse(configuration["HealthChecksUI:EvaluationTimeInSeconds"]!));
                setup.SetApiMaxActiveRequests(int.Parse(configuration["HealthChecksUI:ApiMaxActiveRequests"]!));
                setup.DisableDatabaseMigrations();
                setup.MaximumHistoryEntriesPerEndpoint(50);
            }).AddInMemoryStorage();

            return services;
        }
    }
}
