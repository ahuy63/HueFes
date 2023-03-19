using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
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

        public async Task<IEnumerable<Event>> GetFavouriteEvent()
            => await _dbSet.Where(x => x.Type == 1).Include(x => x.Event).ThenInclude(x => x.EventImages).Select(x => x.Event).ToListAsync();
        public async Task<IEnumerable<Location>> GetFavouriteLocation()
            => await _dbSet.Where(x => x.Type == 2).Include(x => x.Location).Select(x => x.Location).ToListAsync();
        public async Task<IEnumerable<News>> GetFavouriteNews()
            => await _dbSet.Where(x => x.Type == 3).Include(x => x.News).Select(x => x.News).ToListAsync();

    }
}
