using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;

namespace HueFes.Core.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HueFesDbContext context) : base(context)
        {
        }
    }
}
