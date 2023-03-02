using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class TicketService : ITicketService
    {
        public IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> Add(Ticket input)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ticket>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Ticket> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Ticket input)
        {
            throw new NotImplementedException();
        }
    }
}
