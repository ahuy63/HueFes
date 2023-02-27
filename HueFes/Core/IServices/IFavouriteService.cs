using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Core.IServices
{
    public interface IFavouriteService
    {
        Task<FavouriteVM> GetAll();
    }
}
