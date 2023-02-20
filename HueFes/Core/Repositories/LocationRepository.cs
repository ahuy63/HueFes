using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(HueFesDbContext _context) : base(_context)
        {
        }
    }
}
