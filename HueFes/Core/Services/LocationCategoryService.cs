using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class LocationCategoryService : ILocationCategoryService
    {
        public IUnitOfWork _unitOfWork;
        public LocationCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<LocationCategory>> GetAll() => await _unitOfWork.LocationCategoryRepository.GetAllAsync();

        public async Task<LocationCategory> GetById(int id) => await _unitOfWork.LocationCategoryRepository.GetById(id);

        public async Task<bool> Add(LocationCategory locationCategory)
        {
            try
            {
                await _unitOfWork.LocationCategoryRepository.Add(locationCategory);
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
                var locationCate = await _unitOfWork.LocationCategoryRepository.GetById(id);
                if (locationCate != null)
                {
                    if (await _unitOfWork.LocationCategoryRepository.Delete(locationCate))
                    {
                        await _unitOfWork.CommitAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(LocationCategory locationCategory)
        {
            try
            {
                await _unitOfWork.LocationCategoryRepository.Update(locationCategory);
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
