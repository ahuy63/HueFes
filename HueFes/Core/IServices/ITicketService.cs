using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetById(int id);
        Task<bool> Add(Ticket input);
        Task<bool> Delete(int id);
        Task<bool> Update(Ticket input);
    }
}
