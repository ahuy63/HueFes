using HueFes.Models;
using HueFes.ViewModels;

namespace HueFes.Core.IServices
{
    public interface ICheckinService
    {
        Task<IEnumerable<Checkin>> GetAll();
        Task<Checkin> GetById(int id);
        Task<bool> AddCheckinHistory(Checkin checkin);
        Task<bool> Delete(int id);
        Task<bool> Update(Checkin checkin);

        Task<dynamic?> CheckCode(int showId, string code);



        Task<IEnumerable<Checkin>> GetAllByStaffId(int staffId);
        Task<List<BaoCaoDetailsVM>> GetBaoCao(int staffId);

    }
}
