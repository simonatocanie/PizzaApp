using System.ComponentModel.DataAnnotations;

namespace PizzaApp.Domain
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public Category? Category { get; set; }
        public List<Ingredient> Ingredients { get; set; } = [];
        public List<ProductSize> ProductSizes { get; set; } = [];
    }
}
