using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace coder.Application.Infrastructure
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? whereCondition = null,
                                       Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                       List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null);

        Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>> filter, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetSingleByIdAsync(object id);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> filter);
        Task AddAsync(T entity);
        Task AddCollectionAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteCollectionAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateCollectionAsync(IEnumerable<T> entities);
        int SaveChanges();
        Task SaveChangesAsync();
    }
}
