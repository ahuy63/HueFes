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
    public class CheckinsController : ControllerBase
    {
        public ICheckinService _checkinService { get; set; }
        public ITicketService _ticketService { get; set; }
        public readonly IMapper _mapper;
        public CheckinsController(ICheckinService checkinService, IMapper mapper, ITicketService ticketService)
        {
            _checkinService = checkinService;
            _mapper = mapper;
            _ticketService = ticketService;
        }


        [Authorize(Roles ="Staff")]
        [HttpPost("Checkin/{showId}")]
        public async Task<IActionResult> Checkin(int showId, string code)
        {
            var result = await _checkinService.CheckCode(showId, code); //result la bien dynamic
            //Khong hop le        
            if (!result.trangThai)                                      //Khi khong hop le result se tra ve string message    
            {
                return Ok(result.message);
            }

            //Hop le                                                    //Khi hop le result tra ve bien Ticket
            result.ticket.Status = true;                                //Thay doi trang thai ve thanh da kich hoat
            if (await _ticketService.Update(result.ticket))             //Update trang thai ve thanh da kich hoat vao database
            {
                var checkinHistory = new Checkin {                      //Tao bien checkinHistory
                    StaffId = GetCurrentUserId(),                       //StaffId đang đăng nhập
                    TicketId = result.ticket.Id,
                    Status = true,
                    DateCreated = DateTime.Now
                };
                if (await _checkinService.AddCheckinHistory(checkinHistory))
                {
                    var ticketInfo = _mapper.Map<TicketVM>(result.ticket);
                    return Ok(new { message = "Ve hop le!!!\nThong tin ve:\n", ticketInfo });
                }
            }
            return BadRequest("Loi he thong");
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
