using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class CheckinRepository : GenericRepository<Checkin>, ICheckinRepository
    {
        public CheckinRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
