using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class CheckinRepository : GenericRepository<Checkin>, ICheckinRepository
    {
        public CheckinRepository(HueFesDbContext context) : base(context)
        {
        }

        public async Task<List<Checkin>> GetAllByStaffId(int staffId)
        {
            return await _dbSet.Where(x => x.StaffId == staffId)
                .Include(x => x.Staff)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Type)
                .ThenInclude(x => x.Show)
                .ThenInclude(x => x.Event)
                .ToListAsync();
        }

        public async Task<List<BaoCaoDetailsVM>> GetBaoCao(int staffId)
        {
            var result = _dbSet.Where(x => x.StaffId == staffId)
                .Include(x => x.Staff)
                .Include(x => x.Ticket)
                .ThenInclude(x => x.Type)
                .ThenInclude(x => x.Show)
                .ThenInclude(x => x.Event)
                .GroupBy(g => g.Ticket.Type.Show.Event.Name)
                .Select(g => new BaoCaoDetailsVM { EventName = g.First().Ticket.Type.Show.Event.Name, SoLuongVe = g.Count() }).ToList();

            return result;
        }
    }
}
