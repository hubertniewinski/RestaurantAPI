using AutoMapper;
using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using RestaurantAPI.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<DishDto> GetDishes(int restaurantId)
        {
            var restaurant = GetRestaurant(restaurantId);

            var dishesDtos = _mapper.Map<IEnumerable<DishDto>>(restaurant.Dishes);

            return dishesDtos;
        }

        public DishDto GetDish(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurant(restaurantId);

            var dish = GetDish(restaurant, dishId);

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        public DishDto CreateDish(int restaurantId, CreateDishDto createDishDto)
        {
            GetRestaurant(restaurantId);

            var dish = _mapper.Map<Dish>(createDishDto);

            dish.RestaurantId = restaurantId;

            _context.Dishes.Add(dish);
            _context.SaveChanges();

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        public DishDto UpdateDish(int restaurantId, int dishId, UpdateDishDto updateDishDto)
        {
            var restaurant = GetRestaurant(restaurantId);

            var dish = GetDish(restaurant, dishId);

            dish.Name = updateDishDto.Name;
            dish.Description = updateDishDto.Description;
            dish.Price = updateDishDto.Price;

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        public void DeleteDish(int restaurantId, int dishId)
        {
            var restaurant = GetRestaurant(restaurantId);

            var dish = GetDish(restaurant, dishId);

            _context.Dishes.Remove(dish);
            _context.SaveChanges();
        }

        private Restaurant GetRestaurant(int restaurantId)
        {
            var restaurant = _context.Restaurants
                .FirstOrDefault(x => x.Id == restaurantId);

            if (restaurant == null)
                throw new NotFoundException("Restaurant not found");

            return restaurant;
        }

        private Dish GetDish(Restaurant restaurant, int dishId)
        {
            if (restaurant != null)
            {
                var dish = restaurant.Dishes
                    .FirstOrDefault(x => x.Id == dishId);

                if (dish == null)
                    throw new NotFoundException("Dish not found");

                return dish;
            }

            throw new NotFoundException("Restaurant not found");
        }
    }
}
