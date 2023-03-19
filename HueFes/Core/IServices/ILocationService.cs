using HueFes.DomainModels;

namespace HueFes.Core.IServices
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAll();
        Task<Location> GetById(int id);
        Task<bool> Add(Location location);
        Task<bool> Delete(int id);
        Task<bool> Update(Location location);
        Task<bool> AddToFavourite(int id);
        Task<bool> RemoveFavourite(int id);
    }
}
