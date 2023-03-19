using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(HueFesDbContext context) : base(context)
        {
        }

        public async Task<Ticket?> GetByCode(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Code == code);
        }
        public override async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Type)
                .ThenInclude(x => x.Show)
                .ThenInclude(x => x.Event)
                .Include(x => x.Customer)
                .ToListAsync();
        }


        public async Task<Ticket?> CheckCode(int showId, string code)
        {
            return await _dbSet
                .Include(x => x.Type)
                .ThenInclude(x => x.Show)
                .ThenInclude(x => x.Event)
                .FirstOrDefaultAsync(x => x.Type.ShowId == showId && x.Code == code);
                
        }
    }   
}
