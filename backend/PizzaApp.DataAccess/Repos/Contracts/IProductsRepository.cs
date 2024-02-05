using PizzaApp.DataAccess.Helpers;
using PizzaApp.Domain;

namespace PizzaApp.DataAccess.Repos.Contracts
{
    public interface IProductsRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id, bool include = false);
        Task<bool?> DeleteProductAsync(int id);
        Task<bool?> UpdateEntityAsync(Product product, IEnumerable<ProductSizeState> productSizesState, 
            IEnumerable<ProductIngredientState> productIngredientsState);
    }
}
