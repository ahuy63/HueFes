using HueFes.Models;

namespace HueFes.Core.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAll();
        Task<Customer> GetById(int id);
        Task<bool> Add(Customer input);
        Task<bool> Delete(int id);
        Task<bool> Update(Customer input);
    }
}
