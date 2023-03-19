using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface ITicketRepository : IGenericRepository<Ticket>
    {
        Task<Ticket?> CheckCode(int showId, string code);
        Task<Ticket?> GetByCode(string code);
    }
}
