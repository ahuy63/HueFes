using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class TicketTypeRepository : GenericRepository<TicketType>, ITicketTypeRepository
    {
        public TicketTypeRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
