using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Core.IServices
{
    public interface ITicketService
    {

        Task<bool> BuyTicket(List<BuyTicketVM> inputList, int customerId);
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket> GetById(int id);
        Task<bool> CancelTicket(int id);
        Task<bool> Update(Ticket input);
    }
}
