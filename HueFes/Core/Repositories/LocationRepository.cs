using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {
        public LocationRepository(HueFesDbContext _context) : base(_context)
        {
        }

        public async Task<IEnumerable<Location>> GetFavourite()
            => await _dbSet.Where(x => x.Id == 1).ToListAsync();
    }
}
