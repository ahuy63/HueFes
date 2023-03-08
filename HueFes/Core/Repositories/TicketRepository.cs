using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
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
    }
}
