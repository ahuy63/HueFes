using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Core.Services;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        //Nguoi dung da dang nhap
        [Authorize(Roles = "Customer")]
        [HttpGet("GetCurrentUserInfo")]
        public async Task<IActionResult> GetCurrentUserInfo()
        {
            //var currentUserId = Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            int currentUserId = GetCurrentUserId();
            return Ok(_mapper.Map<CustomerVM_Detail>(await _customerService.GetById(currentUserId)));
        }

        [Authorize(Roles = "Customer")]
        [HttpPut("UpdateCurrentUser")]
        public async Task<IActionResult> UpdateCurrentUser(CustomerVM_Update input)
        {
            return await UpdateCustomer(GetCurrentUserId(), input);
        }





        //Quan ly nguoi dung
        [HttpGet("GetAllCustomer")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<CustomerVM>>(await _customerService.GetAll()));
        }

        [HttpGet("GetCustomer/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
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



        private int GetCurrentUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;
                return Int32.Parse(userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
            return 0;
        }
    }
}
