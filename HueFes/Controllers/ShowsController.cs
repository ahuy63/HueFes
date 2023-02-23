using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Models;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        public IShowService _showService { get; set; }
        public readonly IMapper _mapper;

        public ShowsController(IShowService showService, IMapper mapper)
        {
            _showService = showService;
            _mapper = mapper;
        }

        [HttpGet("GetAllShows")]
        public async Task<IActionResult> GetAll() 
            => Ok(_mapper.Map<IEnumerable<ShowVM>>(await _showService.GetAll()).GroupBy(x => x.StartDate));

        [HttpGet("GetByDate")]
        public async Task<IActionResult> GetByDate(DateTime date)
            => Ok(_mapper.Map<IEnumerable<ShowVM>>(await _showService.GetByDate(date)));

        //[HttpGet("GetAllByDate")]
        //public async Task<IEnumerable<IGrouping<DateTime, ShowVM>>> GetAllByDate()
        //{
        //    return _mapper.Map<IEnumerable<ShowVM>>(await _showService.GetAll()).GroupBy(x => x.StartDate);
        //}

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _showService.GetById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<ShowVM_Detail>(result));
            }
            return NotFound();
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(ShowVM_Input input)
        {
            if (await _showService.Add(_mapper.Map<Show>(input)))
            {
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _showService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, ShowVM_Input input)
        {
            var show = await _showService.GetById(id);
            _mapper.Map<ShowVM_Input, Show>(input, show);
            if (await _showService.Update(show))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest();
        }
    }
}
