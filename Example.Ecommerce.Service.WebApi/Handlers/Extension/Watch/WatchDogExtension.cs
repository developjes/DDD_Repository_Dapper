using WatchDog;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Watch
{
    public static class WatchDogExtension
    {
        public static IServiceCollection AddWatchDog(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddWatchDogServices(opt =>
            {
                opt.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
                opt.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
                opt.IsAutoClear = true;
                opt.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
            });

            return services;
        }
    }
}
