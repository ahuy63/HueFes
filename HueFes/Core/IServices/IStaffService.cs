using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Core.IServices
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetAll();
        Task<Staff> GetById(int id);
        Task<Staff?> GetByPhone(string phone);
        Task<string?> Add(Staff staff);
        Task<bool> Delete(int id);
        Task<bool> Update(Staff staff);
        Task<Staff?> Login (StaffVM_Login input);
        Task<bool> ActivateAccount(string phone);
    }
}
