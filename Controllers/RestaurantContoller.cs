using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Dtos;
using RestaurantAPI.Entities;
using RestaurantAPI.Services;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{
    [Route("restaurant")]
    public class RestaurantContoller : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantContoller(IRestaurantService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult<Restaurant> CreateRestaurant([FromBody] Dtos.CreateRestaurantDto createRestaurantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurant = _service.CreateRestaurant(createRestaurantDto);

            return CreatedAtAction(nameof(CreateRestaurant), new { id = restaurant.Id }, restaurant);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetRestaurants()
        {
            var restaurantsDtos = _service.GetRestaurants();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> GetRestaurant(int id)
        {
            var restaurantDto = _service.GetRestaurant(id);

            if(restaurantDto == null)
                return NotFound();

            return Ok(restaurantDto);
        }
    }
}
