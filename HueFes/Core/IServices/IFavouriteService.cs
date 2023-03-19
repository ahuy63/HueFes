using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Core.IServices
{
    public interface IFavouriteService
    {
        Task<FavouriteVM> GetAll();
        Task<Favourite> GetFavouriteEvent(int eventId);
        Task<Favourite> GetFavouriteLocation(int locationId);
        Task<Favourite> GetFavouriteNews(int newsId);

    }
}
