using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.DomainModels;

namespace HueFes.Core.Services
{
    public class TicketTypeService : ITicketTypeService
    {
        public IUnitOfWork _unitOfWork;

        public TicketTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(IEnumerable<TicketType> inputList)
        {
            try
            {
                foreach (var item in inputList)
                {
                    var ticketTypeId = await CheckZone(item); //neu zone ton tai thi update quantity
                    if (ticketTypeId != 0) 
                    {
                        await UpdateTicketQuantity(ticketTypeId, item.Quantity);
                    }
                    else
                    {
                        await _unitOfWork.TicketTypeRepository.Add(item);
                    }
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Check xem zone trong ticketType da ton tai?
        private async Task<int> CheckZone(TicketType item)
        {
            try
            {
                var ticketType = await _unitOfWork.TicketTypeRepository.GetByZone(item.Zone, item.ShowId);
                if (ticketType != null)
                {
                    return ticketType.Id;
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Update luong ve trong kho
        public async Task UpdateTicketQuantity(int ticketTypeId, int quantity)
        {
            try
            {
                var ticketType = await _unitOfWork.TicketTypeRepository.GetById(ticketTypeId);
                ticketType.Quantity += quantity;
                await _unitOfWork.TicketTypeRepository.Update(ticketType);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.TicketTypeRepository.Delete(await _unitOfWork.TicketTypeRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<TicketType> GetById(int id)
        {
            return await _unitOfWork.TicketTypeRepository.GetById(id);
        }

        public async Task<IEnumerable<TicketType>> GetByShowId(int showId)
        {
            return await _unitOfWork.TicketTypeRepository.GetByShowId(showId);
        }

        public async Task<bool> Update(TicketType input)
        {
            try
            {
                await _unitOfWork.TicketTypeRepository.Update(input);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
