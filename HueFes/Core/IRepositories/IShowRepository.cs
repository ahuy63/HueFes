using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface IShowRepository : IGenericRepository<Show>
    {
        Task<IEnumerable<Show>> GetByDate(DateTime date);
        Task<IEnumerable<IGrouping<DateTime, Show>>> GetAllByDate();
    }
}
