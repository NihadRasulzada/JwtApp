using JwtApp.Back.Core.Application.Interfaces;
using JwtApp.Back.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JwtApp.Back.Persistance.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        #region Repository
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AsNoTracking().SingleOrDefaultAsync(expression);
        }

        public async Task<T?> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}
