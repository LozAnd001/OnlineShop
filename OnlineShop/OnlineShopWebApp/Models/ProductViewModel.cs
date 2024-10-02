using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public string? ImagePath { get; set; }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 100000, ErrorMessage = "Цена должна быть в пределах от 1 до 100_000 руб.")]
        public decimal Cost { get; set; }

        [Required]
        public string Description { get; set; }
        
    }
}
