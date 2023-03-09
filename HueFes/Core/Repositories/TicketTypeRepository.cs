using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(HueFesDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TicketType>> GetByShowId(int showId)
        {
            return await _dbSet.Where(x => x.ShowId == showId).ToListAsync();
        }

        public async Task<TicketType> GetByZone(string zone, int showId)
        {
            return await _dbSet.Where(x => x.Zone == zone).Where(x => x.ShowId == showId).FirstOrDefaultAsync();
        }
    }
}
