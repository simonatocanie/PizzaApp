using AutoMapper;
using PizzaApp.BusinessLogic.Models.Ingredients;
using PizzaApp.Domain;
using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.BusinessLogic.Models.ProductSizes;

namespace PizzaApp.BusinessLogic.Mapper
{
    public class ProductsProfile: Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Ingredient, IngredientDto>();
            CreateMap<ProductSize, ProductSizeDto>()
                .ForMember(source=> source.SizeName,
                    dest=> dest.MapFrom(y=> y.Size.Name));
        }
    }
}
