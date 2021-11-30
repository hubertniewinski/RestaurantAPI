using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Dtos
{
    public class UpdateDishDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
