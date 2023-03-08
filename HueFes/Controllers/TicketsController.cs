using AutoMapper;
using HueFes.Core.IServices;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        public ITicketService _ticketService { get; set; }
        public readonly IMapper _mapper;
        public TicketsController(ITicketService ticketService, IMapper mapper)
        {
            _ticketService = ticketService;
            _mapper = mapper;
        }

        //Nguoi dung da dang nhap
        [Authorize(Roles = "Customer")]
        [HttpPost("BuyTicket")]
        public async Task<IActionResult> BuyTicket(List<BuyTicketVM> inputList)
        {
            if (await _ticketService.BuyTicket(inputList, GetCurrentUserId()))
            {
                return Ok("Buy Successfully!!!");
            }
            return Ok("Buy Failed!!!");
        }

        [Authorize(Roles = "Customer")]
        [HttpDelete("CancelTicket/{ticketId}")]
        public async Task<IActionResult> CancelTicket(int ticketId)
        {
            if (await _ticketService.CancelTicket(ticketId))
            {
                return Ok("Cancel Successfully!!!");
            }
            return Ok("Cancel Failed!!!");
        }




        //Check in ve cho staff





        //Quan ly ve



        private int GetCurrentUserId()
        {
            //return Int32.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
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
