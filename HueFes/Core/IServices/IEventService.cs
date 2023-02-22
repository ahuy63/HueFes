using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<IEnumerable<Event>> GetByTieuDiem();
        Task<IEnumerable<Event>> GetByCongDong();
        Task<Event> GetById(int id);
        Task<bool> Add(Event input);
        Task<bool> AddImage(IEnumerable<EventImage> input);
        Task<bool> Delete(int id);
        Task<bool> Update(Event input);
    }
}
