using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.DomainModels;

namespace HueFes.Core.Services
{
    public class ShowService : IShowService
    {
        public IUnitOfWork _unitOfWork;
        public ShowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Show>> GetAll() => await _unitOfWork.ShowRepository.GetAllAsync();
        public async Task<IEnumerable<Show>> GetByDate(DateTime date) => await _unitOfWork.ShowRepository.GetByDate(date);
        public async Task<IEnumerable<IGrouping<DateTime, Show>>> GetAllByDate() => await _unitOfWork.ShowRepository.GetAllByDate();

        public async Task<Show> GetById(int id) => await _unitOfWork.ShowRepository.GetById(id);

        public async Task<bool> Add(Show input)
        {
            try
            {
                await _unitOfWork.ShowRepository.Add(input);
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
                await _unitOfWork.ShowRepository.Delete(await _unitOfWork.ShowRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Show input)
        {
            try
            {
                await _unitOfWork.ShowRepository.Update(input);
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
