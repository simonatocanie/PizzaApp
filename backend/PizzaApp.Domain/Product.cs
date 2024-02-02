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
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new();
        public List<Ingredient> Ingredients { get; set; } = [];
        public List<ProductSize> ProductSizes { get; set; } = [];
        public List<Dough> Doughs { get; set; } = [];
    }
}
