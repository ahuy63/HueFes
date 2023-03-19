using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(HueFesDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<News>> GetFavourite()
            => await _dbSet.Where(x => x.Id == 1).ToListAsync();
    }
}
