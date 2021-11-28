using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        bool DeleteRestaurant(int id);
        Restaurant CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurant(int id);
    }
}