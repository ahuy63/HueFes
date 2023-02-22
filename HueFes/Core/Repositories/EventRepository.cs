using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        public EventRepository(HueFesDbContext context) : base(context)
        {
        }
        public override async Task<Event> GetById(int id)
        {
            return await _dbSet.Include(x => x.EventImages).Include(x => x.Shows).SingleOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Event>> GetByTieuDiem()
            => await _dbSet.Where(x => x.Type_Program == 1).ToListAsync();

        public async Task<IEnumerable<Event>> GetByCongDong()
            => await _dbSet.Where(x => x.Type_Program == 3).ToListAsync();
    }
}
