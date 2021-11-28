using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RestaurantService(RestaurantDbContext context, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<RestaurantDto> GetRestaurants()
        {
            var restaurants = _context
                .Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return restaurantsDtos.ToList();
        }

        public RestaurantDto GetRestaurant(int id)
        {
            var restaurant = _context
                .Restaurants
                .Include(x => x.Address)
                .Include(x => x.Dishes)
                .FirstOrDefault(x => x.Id == id);

            if (restaurant == null)
                return null;

            var restaurantDto = _mapper.Map<Restaurant, RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public RestaurantDto CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

            return restaurantDto;
        }

        public bool DeleteRestaurant(int id)
        {
            _logger.LogWarning($"Restaurant with id: {id} DELETE action invoked");

            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);

            if (restaurant == null)
                return false;

            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();

            return true;
        }

      
        public bool UpdateRestaurant(int id, UpdateRestaurantDto updateRestaurantDto)
        {
            var restaurant = _context.Restaurants.FirstOrDefault(x => x.Id == id);

            if (restaurant == null)
                return false;

            restaurant.Name = updateRestaurantDto.Name;
            restaurant.Description = updateRestaurantDto.Description;
            restaurant.HasDelivery = updateRestaurantDto.HasDelivery;

            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();

            return true;
        }
    }
}
