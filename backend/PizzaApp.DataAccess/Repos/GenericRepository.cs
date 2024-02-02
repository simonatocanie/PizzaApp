using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Repos.Contracts;

namespace PizzaApp.DataAccess.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PizzaDbContext dbContext;

        public GenericRepository(PizzaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }
    }
}
