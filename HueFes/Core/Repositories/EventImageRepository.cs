using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class EventImageRepository : GenericRepository<EventImage>, IEventImageRepository
    {
        public EventImageRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
