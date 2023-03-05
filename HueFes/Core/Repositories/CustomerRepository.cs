using HueFes.Core.IRepositories;
using HueFes.Data;
using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Core.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HueFesDbContext context) : base(context)
        {
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
