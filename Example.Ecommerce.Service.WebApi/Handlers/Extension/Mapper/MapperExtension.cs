using AutoMapper;
using Example.Ecommerce.Transversal.Mapper;

namespace Example.Ecommerce.Service.WebApi.Handlers.Extension.Mapper
{
    public static class MapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            MapperConfiguration mappingConfig = new(mc =>
            {
                mc.AllowNullCollections = true;
                mc.AllowNullDestinationValues = true;
                mc.AddProfiles(new List<Profile> { new MappingProfile() });
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
