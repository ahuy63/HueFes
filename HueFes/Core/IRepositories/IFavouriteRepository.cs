using HueFes.Models;
using System.Threading.Tasks;

namespace HueFes.Core.IRepositories
{
    public interface IFavouriteRepository : IGenericRepository<Favourite>
    {
        Task<Favourite> GetByEventId(int eventId);
        Task<Favourite> GetByLocationId(int locationId);
        Task<Favourite> GetByNewsId(int newsId);
    }
}
