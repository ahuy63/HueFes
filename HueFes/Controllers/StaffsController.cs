using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        public IStaffService _staffService { get; set; }
        public readonly IMapper _mapper;
        public StaffsController(IStaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        //Staff
        [Authorize(Roles ="Staff, Admin")]
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(StaffVM_ChangePassword input)
        {
            var staff = await _staffService.GetById(GetCurrentUserId());

            var message = input.CheckInput(staff.Password); //Check input field
            if (message != null)
            {
                return BadRequest(message);
            }

            staff.Password = input.NewPassword;
            if (await _staffService.Update(staff))
            {
                return Ok("Update Password Successfully!");
            }
            return BadRequest();
        }



        //Admin
        [HttpGet("GetAllStaff")]
        public async Task<IActionResult> GetAllStaff()
        {
            return Ok(await _staffService.GetAll());
        }

        [HttpGet("GetStaff/{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var result = await _staffService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateNew(StaffVM_Create input)
        {
            if (await _staffService.GetByPhone(input.Phone) != null)
            {
                return BadRequest("Phone is existed");
            }

            var password = await _staffService.Add(_mapper.Map<Staff>(input));
            if (password != null)
            {
                return Ok("Add Successfully!!!\n Your Password: " + password);
            }
            return BadRequest();
        }

        [HttpPut("UpdateStaff/{id}")]
        public async Task<IActionResult> UpdateStaff(int id, StaffVM_Update input)
        {
            var staff = await _staffService.GetById(id);
            if (staff != null)
            {
                _mapper.Map<StaffVM_Update, Staff>(input, staff);
                if (await _staffService.Update(staff))
                {
                    return Ok("Update Successfully!!!");
                }
                return BadRequest();
            }
            return NotFound();
        }

        [HttpDelete("DeleteStaff/{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (await _staffService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
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
