using HueFes.DomainModels;

namespace HueFes.Core.IServices
{
    public interface IShowService
    {
        Task<IEnumerable<Show>> GetAll();
        Task<IEnumerable<Show>> GetByDate(DateTime date);
        Task<IEnumerable<IGrouping<DateTime, Show>>> GetAllByDate();
        Task<Show> GetById(int id);
        Task<bool> Add(Show input);
        Task<bool> Delete(int id);
        Task<bool> Update(Show input);
    }
}
