using System.ComponentModel.DataAnnotations;

namespace Group6_Fashion_Merchandise.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Price { get; set; }

        public string ImagePath { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }
    }
}
