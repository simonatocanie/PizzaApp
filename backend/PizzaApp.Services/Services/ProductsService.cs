using AutoMapper;
using PizzaApp.BusinessLogic.Services.Contracts;
using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.DataAccess.Repos.Contracts;
using PizzaApp.Domain;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Helpers;

namespace PizzaApp.BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository productRepo;
        private readonly IMapper mapper;

        public ProductsService(IProductsRepository productRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await productRepo.GetAllProductsAsync();

            return mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDetailDto> GetProductByIdAsync(int id)
        {
            var product = await productRepo.GetProductByIdAsync(id);

            return mapper.Map<ProductDetailDto>(product);
        }

        public async Task<ProductDto> AddProductAsync(ProductCreatedDto createdPoduct)
        {
            var product = mapper.Map<Product>(createdPoduct);
            await productRepo.AddEntityAsync(product);

            return mapper.Map<ProductDto>(product); ;

        }

        public async Task<bool?> UpdateProductAsync(ProductUpdateddDto updatedPoduct)
        {
            var product = await productRepo.GetProductByIdAsync(updatedPoduct.Id, true);

            if (product != null)
            {
                mapper.Map(updatedPoduct, product);
                var productSizesState = UpdateProductSizes(updatedPoduct, product);
                var productIngredientsState = UpdateProductIngredients(updatedPoduct, product);

                return await productRepo.UpdateEntityAsync(product, productSizesState, productIngredientsState);
            }

            return null;

        }

        private IEnumerable<ProductIngredientState> UpdateProductIngredients(ProductUpdateddDto updatedPoduct, Product product)
        {
            var ingredientsToRemove = product.Ingredients
                .Where(x => !updatedPoduct.IngredientsDto.Any(i => i.Id == x.Id))
                 .Select(x =>
                    new ProductIngredientState
                    {
                        ProductIngredient = new() { ProductId = product.Id, IngredientId = x.Id },
                        EntityState = EntityState.Deleted
                    })
                .ToList();

            var existentIngredients = updatedPoduct.IngredientsDto
                .Where(x => !product.Ingredients.Any(i => i.Id == x.Id))
                .Select(x =>
                    new ProductIngredientState
                    {
                        ProductIngredient = new() { ProductId = product.Id, IngredientId = x.Id },
                        EntityState = EntityState.Added
                    })
                .ToList();

            return ingredientsToRemove.Union(existentIngredients);
        }

        private IEnumerable<ProductSizeState> UpdateProductSizes(ProductUpdateddDto updatedPoduct, Product product)
        {
            var productSizesToRemove = product.ProductSizes
                .Where(pi => !updatedPoduct.ProductSizesDto.Any(x => x.SizeId == pi.SizeId && x.ProductId == product.Id))
                .Select(x => new ProductSizeState { ProductSize = x, EntityState = EntityState.Deleted })
                .ToList();

            var newProductSizes = updatedPoduct.ProductSizesDto
                .Where(x => !product.ProductSizes.Any(i => x.SizeId == i.SizeId && i.ProductId == product.Id))
                .Select(x => new ProductSizeState { ProductSize = mapper.Map<ProductSize>(x), EntityState = EntityState.Added })
                .ToList();

            return productSizesToRemove.Union(newProductSizes);
        }

        public async Task<bool?> DeleteProductAsync(int id)
        {
            return await productRepo.DeleteProductAsync(id);
        }
    }
}
