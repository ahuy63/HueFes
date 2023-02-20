using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class LocationCategoryRepository : GenericRepository<LocationCategory>, ILocationCategoryRepository
    {
        public LocationCategoryRepository(HueFesDbContext _context) : base(_context)
        {

        }
        public override async Task<LocationCategory> GetById(int id)
            => await _dbSet.Include(x => x.Locations).FirstOrDefaultAsync(x => x.Id == id);
    }
}
