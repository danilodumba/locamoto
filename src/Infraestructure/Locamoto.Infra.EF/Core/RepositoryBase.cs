using Locamoto.Domain.Core;
using Locamoto.Infra.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Locamoto.Infra.EF.Core
{
    public abstract class RepositoryBase<T> where T : EntityRoot
    {
        protected LocamotoEFContext _context;
        protected DbSet<T> _dbSet;

        protected RepositoryBase(LocamotoEFContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual async Task Create(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public virtual Task Update(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task Remove(T entity)
        {
            _dbSet.Remove(entity);
            return Task.CompletedTask;
        }
        public virtual async Task<T?> GetById(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}