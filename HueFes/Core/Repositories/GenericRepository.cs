using HueFes.Core.IRepositories;
using HueFes.Data;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly HueFesDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(HueFesDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public virtual async Task<T> GetById(int id) => await _dbSet.FindAsync(id);

        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return true;
        }
    }
}
