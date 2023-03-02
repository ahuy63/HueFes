using AutoMapper;
using HueFes.Core.IServices;
using Microsoft.AspNetCore.Mvc;

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


    }
}
