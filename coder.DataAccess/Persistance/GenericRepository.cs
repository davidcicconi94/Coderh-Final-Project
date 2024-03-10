using coder.Application.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using coder.DataAccess.Data;

namespace coder.DataAccess.Persistance
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CoderDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(CoderDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? whereCondition = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                            List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (whereCondition != null)
            {
                query = query.Where(whereCondition);
            }

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        public async Task<T?> GetSingleOrDefaultAsync(Expression<Func<T, bool>> filter, List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? includes = null)
        {
            var query = _dbSet.AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = include(query);
                }
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>>? filter = null)
        {
            return (filter != null) ? await _dbSet.FirstOrDefaultAsync(filter) : await _dbSet.FirstOrDefaultAsync();
        }

        public async Task<T?> GetSingleByIdAsync(object id)
        {
            var response = await _dbSet.FindAsync(id);

            if (response != null)
            {
                _context.Entry(response).State = EntityState.Detached;
            }

            return response;
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddCollectionAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Yield();
            _dbSet.Remove(entity);
        }

        public async Task DeleteCollectionAsync(IEnumerable<T> entities)
        {
            await Task.Yield();
            _dbSet.RemoveRange(entities);
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Yield();
            _dbSet.Update(entity);
        }

        public async Task UpdateCollectionAsync(IEnumerable<T> entities)
        {
            await Task.Yield();
            _dbSet.UpdateRange(entities);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
