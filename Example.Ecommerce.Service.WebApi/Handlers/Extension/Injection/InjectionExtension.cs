using AutoMapper;
using Example.Ecommerce.Application.Interface;
using Example.Ecommerce.Application.Main;
using Example.Ecommerce.Domain.Core;
using Example.Ecommerce.Domain.Interface;
using Example.Ecommerce.Infrastructure.Data;
using Example.Ecommerce.Infrastructure.Interface.Repository;
using Example.Ecommerce.Infrastructure.Interface.UnitOfWork;
using Example.Ecommerce.Infrastructure.Repository.Repository;
using Example.Ecommerce.Infrastructure.Repository.UnitOfWork;
using Example.Ecommerce.Service.WebApi.Handlers.Extension.AntiforgeryCookie;
using Example.Ecommerce.Transversal.Common.Interface;
using Example.Ecommerce.Transversal.Logging;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Injection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSingleton<DapperContext>();
            services.AddTransient<AntiforgeryCookieResultFilter>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IUserDomain, UserDomain>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ICustomerApplication, CustomerApplication>();
            services.AddScoped<ICustomerDomain, CustomerDomain>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<ICategoryApplication, CategoryApplication>();
            services.AddScoped<ICategoryDomain, CategoryDomain>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
