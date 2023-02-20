using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class LocationService : ILocationService
    {
        public IUnitOfWork _unitOfWork;

        public LocationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Location>> GetAll() => await _unitOfWork.LocationRepository.GetAllAsync();

        public async Task<Location> GetById(int id) => await _unitOfWork.LocationRepository.GetById(id);

        public async Task<bool> Add(Location location)
        {
            try
            {
                await _unitOfWork.LocationRepository.Add(location);
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
                var location = await _unitOfWork.LocationRepository.GetById(id);
                if (location != null)
                {
                    if (await _unitOfWork.LocationRepository.Delete(location))
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

        public async Task<bool> Update(Location location)
        {
            try
            {
                await _unitOfWork.LocationRepository.Update(location);
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
