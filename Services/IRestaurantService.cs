using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurant(int id);
        RestaurantDto CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        bool DeleteRestaurant(int id);
        bool UpdateRestaurant(int id, UpdateRestaurantDto updateRestaurantDto);
    }
}