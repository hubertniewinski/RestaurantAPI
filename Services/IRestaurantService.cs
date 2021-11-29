using RestaurantAPI.Dtos;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IRestaurantService
    {
        IEnumerable<RestaurantDto> GetRestaurants();
        RestaurantDto GetRestaurant(int id);
        RestaurantDto CreateRestaurant(CreateRestaurantDto createRestaurantDto);
        void DeleteRestaurant(int id);
        void UpdateRestaurant(int id, UpdateRestaurantDto updateRestaurantDto);
    }
}