using PizzaApp.Data;
using PizzaApp.DataAccess.Repos.Contracts;
using PizzaApp.Domain;

namespace PizzaApp.DataAccess.Repos
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(PizzaDbContext dbContext) : base(dbContext)
        {
        }
    }
}
