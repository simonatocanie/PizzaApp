
using PizzaApp.BusinessLogic.Models.Dough;
using PizzaApp.BusinessLogic.Models.Ingredients;
using PizzaApp.BusinessLogic.Models.ProductSizes;

namespace PizzaApp.BusinessLogic.Models.Products
{
    public class ProductDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<IngredientDto> IngredientsDto { get; set; } = [];
        public List<ProductSizeDto> ProductSizesDto { get; set; } = [];
        public List<DoughDto> DoughsDto { get; set; } = [];
    }
}
