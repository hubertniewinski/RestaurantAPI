using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Dtos;
using RestaurantAPI.Services;
using System.Collections.Generic;

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


        [HttpPost]
        public ActionResult<RestaurantDto> CreateRestaurant([FromBody] Dtos.CreateRestaurantDto createRestaurantDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var restaurantDto = _service.CreateRestaurant(createRestaurantDto);

            return CreatedAtAction(nameof(CreateRestaurant), new { id = restaurantDto.Id }, restaurantDto);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestaurant(int id)
        {
            var deleted = _service.DeleteRestaurant(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRestaurant(int id, [FromBody] UpdateRestaurantDto updateRestaurantDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _service.UpdateRestaurant(id, updateRestaurantDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}
