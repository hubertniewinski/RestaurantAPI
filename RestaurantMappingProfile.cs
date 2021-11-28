using AutoMapper;
using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<Dish, DishDto>();
            CreateMap<Address, AddressDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(x => x.Address, c => c.MapFrom(dto => new Address() { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));

            CreateMap<Restaurant, CreateRestaurantDto>()
                .ForMember(x => x.City, c => c.MapFrom(s => s.Address.City));
            CreateMap<Restaurant, CreateRestaurantDto>()
                .ForMember(x => x.Street, c => c.MapFrom(s => s.Address.Street));
            CreateMap<Restaurant, CreateRestaurantDto>()
                .ForMember(x => x.PostalCode, c => c.MapFrom(s => s.Address.PostalCode));
        }
    }
}
