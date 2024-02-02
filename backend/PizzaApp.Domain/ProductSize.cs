

using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class ProductSize
    {
        public int SizeId { get; set; }
        public Size? Size { get; set; } = new();
        public int ProductId { get; set; }
        public Product? Product { get; set; } = new();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int Counter { get; set; }
    }
}
