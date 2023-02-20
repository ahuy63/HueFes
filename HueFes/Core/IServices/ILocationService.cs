using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetAll();
        Task<Location> GetById(int id);
        Task<bool> Add(Location location);
        Task<bool> Delete(int id);
        Task<bool> Update(Location location);
    }
}
