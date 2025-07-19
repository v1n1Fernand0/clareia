using Clareia.Domain.Interfaces;
using Clareia.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clareia.Infrastructure.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class,
        IAuditedBaseEntity<TKey> where TKey : struct
    {
        private readonly ClareiaAppContext _context;
        public Repository(ClareiaAppContext context)
        {
            _context = context;
        }
        public async Task<T?> GetByIdAsync(TKey id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(TKey id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<T>> FindAsync(Func<T, bool> predicate)
        {
            return await Task.FromResult(_context.Set<T>().Where(predicate).ToList());
        }
    }

}
