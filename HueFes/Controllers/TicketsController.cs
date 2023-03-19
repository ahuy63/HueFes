using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
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
            foreach (var item in inputList)                         //Check so luong ve trong kho
            {
                if (!await _ticketService.CheckQuantity(item.TicketTypeId, item.quantity))
                {
                    return Ok("không đủ số lượng vé!!!");
                }
            }
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


        [HttpGet("GetTicketQR/{ticketId}")]
        public async Task<IActionResult> GetTicketQR(int ticketId)
        {
            var ticket = await _ticketService.GetById(ticketId);
            if (ticket == null)
            {
                return NotFound();
            }
            var ticketVM = _mapper.Map<TicketVM>(ticket);
            return File(QRGenerator(ticket.Code), "image/jpeg");
        }

        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            return Ok(_mapper.Map<TicketVM>(await _ticketService.GetByCode(code)));
        }




        private byte[] QRGenerator(string code)
        {
            //string url = "https://localhost:7236/api/Tickets/GetByCode?code=" + code;
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(10);
            return qrCodeAsBitmapByteArr;
        }





        //Quan ly ve
        [HttpGet("GetAllTicket")]
        public async Task<IActionResult> GetAllTicket()
        {
            return Ok(_mapper.Map<IEnumerable<TicketVM>>(await _ticketService.GetAll()));
        }






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
