using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetByTieuDiem();
        Task<IEnumerable<Event>> GetByCongDong();
    }
}
