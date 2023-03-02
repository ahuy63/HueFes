using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

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
                    await _unitOfWork.TicketTypeRepository.Add(item);
                }
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
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

        public Task<TicketType> GetById(int id)
        {
            return _unitOfWork.TicketTypeRepository.GetById(id);
        }

        public Task<TicketType> GetByShowId(int showId)
        {
            throw new NotImplementedException();
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
