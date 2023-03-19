using HueFes.DomainModels;

namespace HueFes.Core.IRepositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetByPhone(string phone);
        Task<Customer> GetByEmail(string email);
        Task<Customer> Create(Customer customer);
    }
}
