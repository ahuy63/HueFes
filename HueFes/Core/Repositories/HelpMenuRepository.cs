using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;

namespace HueFes.Core.Repositories
{
    public class HelpMenuRepository : GenericRepository<HelpMenu>, IHelpMenuRepository
    {
        public HelpMenuRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
