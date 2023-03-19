using HueFes.DomainModels;
using HueFes.ViewModels;

namespace HueFes.Core.IRepositories
{
    public interface ICheckinRepository : IGenericRepository<Checkin>
    {
        public Task<List<Checkin>> GetAllByStaffId(int staffId);
        Task<List<BaoCaoDetailsVM>> GetBaoCao(int staffId);
    }
    
}
