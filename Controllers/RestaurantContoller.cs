using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Dtos;
using RestaurantAPI.Services;
using System.Collections.Generic;

namespace RestaurantAPI.Controllers
{
    [Route("restaurant")]
    [ApiController]
    public class RestaurantContoller : ControllerBase
    {
        private readonly IRestaurantService _service;

        public RestaurantContoller(IRestaurantService service)
        {
            _service = service;
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

            return Ok(restaurantDto);
        }


        [HttpPost]
        public ActionResult<RestaurantDto> CreateRestaurant([FromBody] Dtos.CreateRestaurantDto createRestaurantDto)
        {
            var restaurantDto = _service.CreateRestaurant(createRestaurantDto);

            return CreatedAtAction(nameof(CreateRestaurant), new { id = restaurantDto.Id }, restaurantDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant(int id)
        {
            _service.DeleteRestaurant (id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant(int id, [FromBody] UpdateRestaurantDto updateRestaurantDto)
        {
            _service.UpdateRestaurant(id, updateRestaurantDto);

            return NoContent();
        }
    }
}
