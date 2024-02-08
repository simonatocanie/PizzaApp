using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PizzaApp.Data;
using PizzaApp.DataAccess.Helpers;
using PizzaApp.DataAccess.Repos.Contracts;
using PizzaApp.Domain;

namespace PizzaApp.DataAccess.Repos
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        private readonly LocalDbContext dbContext;

        public ProductsRepository(LocalDbContext dbContext, ILogger<ProductsRepository> logger) : base(dbContext, logger)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {

            var query = base.GetAllAsync(x => x.Ingredients, x => x.Category.Doughs)
                        .Where(x => !x.IsDeleted)
                        .Include(x => x.ProductSizes)
                        .ThenInclude(x => x.Size);  // for the moment no solution found for generic for theninclude

            return await query.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id, bool include = false)
        {
            var query = base.GetByIdAsync(id).Where(x => !x.IsDeleted);

            if (include)
            {
                query = query
                    .Include(x => x.Ingredients)
                    .Include(x => x.ProductSizes)
                    .ThenInclude(x => x.Size);
            }

            return await query.AsNoTracking()
              .FirstOrDefaultAsync();
        }

        public async Task<bool?> DeleteProductAsync(int id)
        {
            var product = await base.GetByIdAsync(id).Where(x => !x.IsDeleted).FirstOrDefaultAsync();
            if (product == null)
            {
                return null;
            }

            product.IsDeleted = true;
            return await UpdateEntityAsync(product);
        }

        public async Task<bool?> UpdateEntityAsync(Product product, IEnumerable<ProductSizeState> productSizesState, IEnumerable<ProductIngredientState> productIngredientsState)
        {
            foreach (var item in productSizesState)
            {
                dbContext.Entry(item.ProductSize).State = item.EntityState;
            }

            foreach (var item in productIngredientsState)
            {
                dbContext.Entry(item.ProductIngredient).State = item.EntityState;
            }

            return await base.UpdateEntityAsync(product);
        }
    }
}
