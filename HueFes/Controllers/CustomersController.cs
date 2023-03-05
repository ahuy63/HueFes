using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Core.Services;
using HueFes.Models;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerService _customerService { get; set; }
        public readonly IMapper _mapper;

        public CustomersController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAll() {
            return Ok(_mapper.Map<IEnumerable<CustomerVM>>( await _customerService.GetAll()));
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            return Ok(_mapper.Map<CustomerVM>(await _customerService.GetById(id)));
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (await _customerService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerVM_Update input)
        {
            var customer = await _customerService.GetById(id);
            if (customer != null)
            {
                _mapper.Map<CustomerVM_Update, Customer>(input, customer);
                if (await _customerService.Update(customer))
                {
                    return Ok("Update Successfully!!!");
                }
                return BadRequest();
            }
            return NotFound();
            
        }
    }
}
