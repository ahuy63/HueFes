using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;
using HueFes.ViewModels;
using HueFes.DomainModels;

namespace HueFes.Core.Services
{
    using BCrypt.Net;
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

        public async Task<string?> Add(Staff staff)
        {
            try
            {
                var password = staff.Password; //Password duoc tu dong khoi tao trong class StaffVM_Create     //luu bien password de return 
                //staff.Password = PasswordHashPbkdf2.HashPassword(staff.Password);         //Hash Password pbkdf2

                staff.Password = BCrypt.HashPassword(staff.Password);

                await _unitOfWork.StaffRepository.Add(staff);
                await _unitOfWork.CommitAsync();
                return password;
            }
            catch (Exception)
            {
                return null;
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

        public async Task<Staff?> GetByPhone(string phone)
        {
            return await _unitOfWork.StaffRepository.GetByPhone(phone);
        }

        public async Task<Staff?> Login(StaffVM_Login input)
        {
            try
            {
                var result = await _unitOfWork.StaffRepository.GetByPhone(input.Phone);
                if (result == null)
                {
                    return null;
                }
                if (BCrypt.Verify(input.Password, result.Password))
                {
                    return result;
                }
                //if(PasswordHashPbkdf2.ValidatePassword(input.Password, result.Password))  //pbkdf2
                //{
                //    return result;
                //}


                return null;
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
                //staff.Password = PasswordHashPbkdf2.HashPassword(staff.Password);  //pbkdf2
                staff.Password = BCrypt.HashPassword(staff.Password);
                await _unitOfWork.StaffRepository.Update(staff);
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
