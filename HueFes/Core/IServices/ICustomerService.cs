using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<Customer> GetByPhone(string phone);
        Task<Customer> GetByEmail(string email);
        Task<Customer?> Add(Customer input);
        Task<bool> Delete(int id);
        Task<bool> Update(Customer input);
    }
}
