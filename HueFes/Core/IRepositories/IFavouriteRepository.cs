using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface IFavouriteRepository : IGenericRepository<Favourite>
    {
        Task<Favourite> GetByEventId(int eventId);
        Task<Favourite> GetByLocationId(int locationId);
        Task<Favourite> GetByNewsId(int newsId);
        Task<IEnumerable<Event>> GetFavouriteEvent();
        Task<IEnumerable<Location>> GetFavouriteLocation();
        Task<IEnumerable<News>> GetFavouriteNews();
    }
}
