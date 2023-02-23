using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class EventService : IEventService
    {
        public IUnitOfWork _unitOfWork;
        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> GetAll() => await _unitOfWork.EventRepository.GetAllAsync();

        public async Task<IEnumerable<Event>> GetByTieuDiem() => await _unitOfWork.EventRepository.GetByTieuDiem();

        public async Task<IEnumerable<Event>> GetByCongDong() => await _unitOfWork.EventRepository.GetByCongDong();

        public async Task<Event> GetById(int id) => await _unitOfWork.EventRepository.GetById(id);


        public async Task<bool> Add(Event input)
        {
            try
            {
                await _unitOfWork.EventRepository.Add(input);
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
                await _unitOfWork.EventRepository.Delete(await _unitOfWork.EventRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Event input)
        {
            try
            {
                await _unitOfWork.EventRepository.Update(input);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddImage(IEnumerable<EventImage> input)
        {
            try
            {
                foreach (var item in input)
                {
                    await _unitOfWork.EventImageRepository.Add(item);
                }
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
