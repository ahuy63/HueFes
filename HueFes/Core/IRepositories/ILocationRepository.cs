using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetFavourite();
    }
}
