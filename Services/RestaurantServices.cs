﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Services
{
    public class RestaurantServices : IRestaurantService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public RestaurantServices(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Restaurant CreateRestaurant(CreateRestaurantDto createRestaurantDto)
        {
            var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);

            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();

            return restaurant;
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
    }
}