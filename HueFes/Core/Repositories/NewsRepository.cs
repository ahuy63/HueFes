using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
