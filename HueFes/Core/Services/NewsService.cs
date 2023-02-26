using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class NewsService : INewsService
    {
        public IUnitOfWork _unitOfWork;
        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(News input)
        {
            try
            {
                await _unitOfWork.NewsRepository.Add(input);
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
                await _unitOfWork.NewsRepository.Delete(await _unitOfWork.NewsRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public async Task<IEnumerable<News>> GetAll()
            => await _unitOfWork.NewsRepository.GetAllAsync();

        public async Task<News> GetById(int id)
            => await _unitOfWork.NewsRepository.GetById(id);

        public async Task<bool> Update(News input)
        {
            try
            {
                await _unitOfWork.NewsRepository.Update(input);
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
