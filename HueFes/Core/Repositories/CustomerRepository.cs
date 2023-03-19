using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HueFesDbContext context) : base(context)
        {
        }
        public override async Task<Customer?> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id)
                .Include(x => x.Tickets)
                .ThenInclude(x => x.Type)
                .ThenInclude(x => x.Show)
                .ThenInclude(x => x.Event)
                .FirstOrDefaultAsync();
        }
        public async Task<Customer> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Customer> GetByPhone(string phone) {
            return await _dbSet.FirstOrDefaultAsync(x => x.Phone == phone);
        }
        public async Task<Customer> Create(Customer customer)
        {
            var result = await _dbSet.AddAsync(customer);
            return result.Entity;
        }
    }
}
