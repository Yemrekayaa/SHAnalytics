using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Interfaces;
using System.Linq.Expressions;

namespace SHAnalytics.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Remove(T Entity)
        {
            _context.Set<T>().Remove(Entity);
            _context.SaveChanges();
        }

        public void Update(T Entity)
        {
            _context.Set<T>().Update(Entity);
            _context.SaveChanges();
        }
    }
}
