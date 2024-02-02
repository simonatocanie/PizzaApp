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
        public int ProductId { get; set; }
        public ProductType ProductType { get; set; } = new();
        public List<Ingredient>? Ingredients { get; set; } = [];
        public List<ProductSize> ProductSizes { get; set; } = [];
    }
}
