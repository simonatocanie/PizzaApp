using PizzaApp.BusinessLogic.Models.Products;

namespace PizzaApp.BusinessLogic.Services.Contracts
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
    }
}
