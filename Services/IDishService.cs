using RestaurantAPI.Dtos;
using System.Collections.Generic;

namespace RestaurantAPI.Services
{
    public interface IDishService
    {
        IEnumerable<DishDto> GetDishes(int restaurantId);
        DishDto GetDish(int restaurantId, int dishId);
        DishDto CreateDish(int restaurantId, CreateDishDto createDishDto);
        DishDto UpdateDish(int restaurantId, int dishId, UpdateDishDto updateDishDto);
        void DeleteDish(int restaurantId, int dishId);
    }
}
