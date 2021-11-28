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
        }
    }
}
