using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        Restaurant CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurant(int id);
    }
}