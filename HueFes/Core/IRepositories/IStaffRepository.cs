using HueFes.Models;

namespace HueFes.Core.IRepositories
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task<Staff?> Login(string phone, string password);
        Task<Staff?> GetByPhone(string phone);
    }
}
