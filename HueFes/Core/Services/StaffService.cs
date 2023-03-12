using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Core.Services
{
    public class StaffService : IStaffService
    {
        public IUnitOfWork _unitOfWork;
        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> ActivateAccount(string phone)
        {
            try
            {
                var staff = await _unitOfWork.StaffRepository.GetByPhone(phone);
                if (staff != null)
                {
                    staff.Status = true;
                    await _unitOfWork.StaffRepository.Update(staff);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public async Task<bool> Add(Staff staff)
        {
            try
            {
                await _unitOfWork.StaffRepository.Add(staff);
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
                await _unitOfWork.StaffRepository.Delete(await _unitOfWork.StaffRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Staff>> GetAll()
        {
            return await _unitOfWork.StaffRepository.GetAllAsync();
        }

        public async Task<Staff> GetById(int id)
        {
            return await _unitOfWork.StaffRepository.GetById(id);
        }

        public async Task<Staff?> Login(StaffVM_Login input)
        {
            try
            {
                return await _unitOfWork.StaffRepository.Login(input.Phone, input.Password);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Update(Staff staff)
        {
            try
            {
                await _unitOfWork.StaffRepository.Update(staff);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string GeneratePassword()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var pass = new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            return pass;
        }
    }
}
