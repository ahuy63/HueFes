using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class FavouriteRepository : GenericRepository<Favourite>, IFavouriteRepository
    {
        public FavouriteRepository(HueFesDbContext context) : base(context)
        {
        }
        public async Task<Favourite> GetByEventId(int eventId)
            => await _dbSet.FirstOrDefaultAsync(x => x.EventId == eventId);
        public async Task<Favourite> GetByLocationId(int locationId)
            => await _dbSet.FirstOrDefaultAsync(x => x.LocationId == locationId);
        public async Task<Favourite> GetByNewsId(int newsId)
            => await _dbSet.FirstOrDefaultAsync(x => x.NewsId == newsId);
    }
}
