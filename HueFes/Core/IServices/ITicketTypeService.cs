using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface ITicketTypeService
    {
        Task<TicketType> GetByShowId(int showId);
        Task<TicketType> GetById(int id);
        Task<bool> Add(IEnumerable<TicketType> inputList);
        Task<bool> Delete(int id);
        Task<bool> Update(TicketType input);
    }
}
