using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface INewsRepository : IGenericRepository<News>
    {
        Task<IEnumerable<News>> GetFavourite();
    }
}
