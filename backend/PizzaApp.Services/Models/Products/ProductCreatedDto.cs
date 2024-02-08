using PizzaApp.BusinessLogic.Models.Ingredients;
using PizzaApp.BusinessLogic.Models.ProductSizes;
using System.ComponentModel.DataAnnotations;

namespace PizzaApp.BusinessLogic.Models.Products
{
    public class ProductCreatedDto
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }
        public List<IngredientDto> IngredientsDto { get; set; } = [];
        public List<ProductSizeDto> ProductSizesDto { get; set; } = [];
    }
}
