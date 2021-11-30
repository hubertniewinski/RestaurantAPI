using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Dtos
{
    public class CreateDishDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
