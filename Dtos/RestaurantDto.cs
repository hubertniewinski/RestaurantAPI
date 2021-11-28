using System.Collections.Generic;

namespace RestaurantAPI.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool HasDelivery { get; set; }
        public AddressDto Address { get; set; }
        public List<DishDto> Dishes { get; set; }
    }
}
