using System.Linq.Expressions;

namespace PizzaApp.DataAccess.Repos.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAllAsync(params Expression<Func<T, object>>[] includes);
        IQueryable<T> GetByIdAsync(int id);
        Task AddEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
