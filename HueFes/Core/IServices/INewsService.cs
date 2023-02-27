using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface INewsService
    {
        Task<IEnumerable<News>> GetAll();
        Task<News> GetById(int id);
        Task<bool> Add(News input);
        Task<bool> Delete(int id);
        Task<bool> Update(News input);
        Task<bool> AddToFavourite(int id);
        Task<bool> RemoveFavourite(int id);
    }
}
