using PizzaApp.Data;
using Microsoft.EntityFrameworkCore;
using PizzaApp.DataAccess.Repos.Contracts;
using System.Linq.Expressions;

namespace PizzaApp.DataAccess.Repos
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LocalDbContext dbContext;

        public GenericRepository(LocalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<T> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = dbContext.Set<T>().AsQueryable();

            if (includes.Count() > 0)
            {
                query = includes.Aggregate(query, (x, includeProperty) => x.Include(includeProperty));
            }

            return query;
        }

        public IQueryable<T> GetByIdAsync(int id)
        {
            var query = dbContext.Set<T>().Where(x => EF.Property<int>(x, "Id") == id); //need iquerable, as convention all primary keys will have the name Id

            return query;
        }

        public async Task AddEntityAsync(T entity)
        {

            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }

            await dbContext.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task<bool> UpdateEntityAsync(T entity)
        {

            if (dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbContext.Set<T>().Attach(entity);
            }

            dbContext.Entry(entity).State = EntityState.Modified;
            var isSaved = await SaveChangesAsync();

            return isSaved != 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}