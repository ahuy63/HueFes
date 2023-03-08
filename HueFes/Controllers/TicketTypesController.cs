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
    public class TicketTypesController : ControllerBase
    {
        public ITicketTypeService _ticketTypeService;
        public IShowService _showService;
        public readonly IMapper _mapper;
        public TicketTypesController(ITicketTypeService ticketTypeService, IShowService showService, IMapper mapper)
        {
            _ticketTypeService = ticketTypeService;
            _showService = showService;
            _mapper = mapper;
        }

        [HttpGet("GetByShow/{showId}")]
        public async Task<IActionResult> GetByShowId(int showId)
        {
            var a = await _ticketTypeService.GetByShowId(showId);
            return Ok(_mapper.Map<IEnumerable<TicketTypeVM>>(await _ticketTypeService.GetByShowId(showId)));
        }

        [HttpPost("AddTicketType/{showId}")]
        public async Task<IActionResult> AddTicketType(int showId, List<TicketTypeVM_Input> inputList)
        {
            var show = await _showService.GetById(showId);
            
            //inputList.All(x => { x.ShowId = showId; return true; });
            var mappedInput = _mapper.Map<List<TicketType>>(inputList);
            mappedInput.ForEach(x => x.ShowId = showId);
            if (await _ticketTypeService.Add(mappedInput))
            {
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("UpdateTicketType/{id}")]
        public async Task<IActionResult> UpdateTicketType(int id, TicketTypeVM_Input input)
        {
            var ticketType = await _ticketTypeService.GetById(id);
            _mapper.Map<TicketTypeVM_Input, TicketType>(input, ticketType);
            if (await _ticketTypeService.Update(ticketType))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("DeleteTicketType/{id}")]
        public async Task<IActionResult> DeleteTicketType(int id)
        {
            if (await _ticketTypeService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }
    }
}
