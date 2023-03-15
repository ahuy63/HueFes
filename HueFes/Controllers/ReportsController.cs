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
    public class ReportsController : ControllerBase
    {
        public ITicketService _ticketService { get; set; }
        public ICheckinService _checkinService { get; set; }
        public readonly IMapper _mapper;

        public ReportsController(ITicketService ticketService, ICheckinService checkinService, IMapper mapper)
        {
            _ticketService = ticketService;
            _checkinService = checkinService;
            _mapper = mapper;
        }


        [Authorize(Roles ="Staff")]
        [HttpGet("GetCheckinHistory")]
        public async Task<IActionResult> GetCheckinHistory(DateTime? theoNgay, int? chuongTrinhId, string? loaiVe)
        {
            var allHistory = _mapper.Map<List<CheckinVM>>(await _checkinService.GetAllByStaffId(GetCurrentUserId()));

            return Ok(new SoatVeHistory(theoNgay, loaiVe, chuongTrinhId, allHistory));
        }


        [Authorize(Roles = "Staff")]
        [HttpGet("GetBaoCao")]
        public async Task<IActionResult> GetBaoCao()
        {
            return Ok(await _checkinService.GetBaoCao(GetCurrentUserId()));
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
