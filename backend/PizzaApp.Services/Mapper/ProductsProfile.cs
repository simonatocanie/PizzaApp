using AutoMapper;
using PizzaApp.BusinessLogic.Models.Ingredients;
using PizzaApp.Domain;
using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.BusinessLogic.Models.ProductSizes;
using PizzaApp.BusinessLogic.Models.Dough;

namespace PizzaApp.BusinessLogic.Mapper
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, ProductDto>()
                    .ForMember(source => source.DoughsDto, dest => dest.MapFrom(x => x.Category.Doughs))
                    .ForMember(source => source.ProductSizesDto, dest => dest.MapFrom(x => x.ProductSizes))
                    .ForMember(source => source.IngredientsDto, dest => dest.MapFrom(x => x.Ingredients));


            CreateMap<ProductCreatedDto, Product>()
                  .ForMember(source => source.ProductSizes, dest => dest.MapFrom(x => x.ProductSizesDto))
                  .ForMember(source => source.Category, dest => dest.Ignore())
                  .ForMember(source => source.Ingredients, dest => dest.MapFrom(x => x.IngredientsDto));

            CreateMap<ProductUpdateddDto, Product>();

            CreateMap<Product, ProductDetailDto>()
                .ForMember(source => source.DoughsDto, dest => dest.MapFrom(x => x.Category.Doughs))
                .ForMember(source => source.ProductSizesDto, dest => dest.MapFrom(x => x.ProductSizes))
                .ForMember(source => source.IngredientsDto, dest => dest.MapFrom(x => x.Ingredients));

            CreateMap<Ingredient, IngredientDto>().ReverseMap();
            CreateMap<Dough, DoughDto>().ReverseMap();

            CreateMap<ProductSize, ProductSizeDto>()
                .ForMember(source => source.SizeName, dest => dest.MapFrom(x => x.Size.Name));

            CreateMap<ProductSizeDto, ProductSize>();

        }
    }
}
