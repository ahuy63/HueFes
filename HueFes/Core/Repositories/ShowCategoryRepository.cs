using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;

namespace HueFes.Core.Repositories
{
    public class ShowCategoryRepository : GenericRepository<ShowCategory>, IShowCategoryRepository
    {
        public ShowCategoryRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
