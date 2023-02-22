using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class ShowCategoryService : IShowCategoryService
    {
        public IUnitOfWork _unitOfWork;
        public ShowCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<ShowCategory>> GetAll() => _unitOfWork.ShowCategoryRepository.GetAllAsync();

        public Task<ShowCategory> GetById(int id) => _unitOfWork.ShowCategoryRepository.GetById(id);

        public async Task<bool> Add(ShowCategory input)
        {
            try
            {
                await _unitOfWork.ShowCategoryRepository.Add(input);
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
                await _unitOfWork.ShowCategoryRepository.Delete(await _unitOfWork.ShowCategoryRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(ShowCategory input)
        {
            try
            {
                await _unitOfWork.ShowCategoryRepository.Update(input);
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
