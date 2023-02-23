using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class ShowRepository : GenericRepository<Show>, IShowRepository
    {
        public ShowRepository(HueFesDbContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Show>> GetAllAsync()
        {
            return await _dbSet.Include(x => x.Event).Include(x => x.Location).ToListAsync();
        }
        public async Task<IEnumerable<Show>> GetByDate(DateTime date)
        {
            return await _dbSet.Where(x => x.StartDate.Date == date).Include(x => x.Event).Include(x => x.Location).ToListAsync();
        }

        public async Task<IEnumerable<IGrouping<DateTime,Show>>> GetAllByDate()
            => await _dbSet.GroupBy(x => x.StartDate).ToListAsync();
    }
}
