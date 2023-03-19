using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface IStaffRepository : IGenericRepository<Staff>
    {
        Task<Staff?> GetByPhone(string phone);
    }
}
