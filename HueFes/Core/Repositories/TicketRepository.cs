using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public TicketRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
