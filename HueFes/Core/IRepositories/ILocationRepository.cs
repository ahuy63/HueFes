using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        Task<IEnumerable<Location>> GetFavourite();
    }
}
