using HueFes.Core.Repositories;
using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface INewsRepository : IGenericRepository<News>
    {
        Task<IEnumerable<News>> GetFavourite();
    }
}
