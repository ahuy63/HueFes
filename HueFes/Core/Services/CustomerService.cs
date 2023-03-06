using HueFes.Core.IServices;
using HueFes.Data;
using HueFes.Models;


namespace HueFes.Core.Services
{
    public class CustomerService : ICustomerService
    {
        public IUnitOfWork _unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Customer?> Add(Customer input)
        {
            try
            {
                input.Role = "Customer";
                var result = await _unitOfWork.CustomerRepository.Create(input);
                await _unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await _unitOfWork.CustomerRepository.Delete(await _unitOfWork.CustomerRepository.GetById(id));
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _unitOfWork.CustomerRepository.GetAllAsync();
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _unitOfWork.CustomerRepository.GetByEmail(email);
        }

        public async Task<Customer> GetById(int id)
        {
            return await _unitOfWork.CustomerRepository.GetById(id);
        }

        public async Task<Customer> GetByPhone(string phone)
        {
            return await _unitOfWork.CustomerRepository.GetByPhone(phone);
        }
        public async Task<bool> Update(Customer input)
        {
            try
            {
                await _unitOfWork.CustomerRepository.Update(input);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
