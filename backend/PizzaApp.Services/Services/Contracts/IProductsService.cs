using PizzaApp.BusinessLogic.Models.Products;
using PizzaApp.Domain;

namespace PizzaApp.BusinessLogic.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();
        Task<ProductDetailDto> GetProductByIdAsync(int id);
        Task<ProductDto> AddProductAsync(ProductCreatedDto createdPoduct);
        Task<bool?> UpdateProductAsync(ProductUpdateddDto updatedPoduct);
        Task<bool?> DeleteProductAsync(int id);
    }
}
