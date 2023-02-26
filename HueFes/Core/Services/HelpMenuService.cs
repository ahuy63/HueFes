using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Services
{
    public class HelpMenuService : IHelpMenuService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public HelpMenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Add(HelpMenu input)
        {
            try
            {
                await _unitOfWork.HelpMenuRepository.Add(input);
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
                await _unitOfWork.HelpMenuRepository.Delete(await _unitOfWork.HelpMenuRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<HelpMenu>> GetAll()
            => await _unitOfWork.HelpMenuRepository.GetAllAsync();

        public async Task<HelpMenu> GetById(int id)
            => await _unitOfWork.HelpMenuRepository.GetById(id);

        public async Task<bool> Update(HelpMenu input)
        {
            try
            {
                await _unitOfWork.HelpMenuRepository.Update(input);
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
