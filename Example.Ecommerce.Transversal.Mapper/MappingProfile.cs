using AutoMapper;
using Example.Ecommerce.Application.DTO;
using Example.Ecommerce.Domain.Entity;

namespace Example.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapperRules();
        }

        private void MapperRules()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
