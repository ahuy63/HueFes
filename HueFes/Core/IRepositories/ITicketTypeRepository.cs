using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface ITicketTypeRepository : IGenericRepository<TicketType>
    {
        Task<IEnumerable<TicketType>> GetByShowId(int showId);
        Task<TicketType> GetByZone(string zone, int showId);
    }
}
