using Example.Ecommerce.Application.Validator;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Validator
{
    public static class ValidatorExtension
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<UserDtoValidator>();

            return services;
        }
    }
}
