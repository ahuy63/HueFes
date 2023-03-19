using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Core.Services;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class LocationsController : ControllerBase
    {
        public ILocationService _locationService { get; set; }
        public readonly IMapper _mapper;
        public LocationsController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        [HttpGet("GetAllLocation")]
        public async Task<IActionResult> GetAll() => Ok(_mapper.Map<IEnumerable<LocationVM>>(await _locationService.GetAll()));

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _locationService.GetById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<LocationVM>(result));
            }
            return NotFound();
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> Add(LocationVM_Input input)
        {
            var mappedInput = _mapper.Map<Location>(input);
            if (await _locationService.Add(mappedInput))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Update(int id, LocationVM_Input input)
        {
            var location = await _locationService.GetById(id);
            _mapper.Map<LocationVM_Input, Location>(input, location);
            if (await _locationService.Update(location))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest("Update Failed!!!");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _locationService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPost("AddFavourite/{id}")]
        public async Task<IActionResult> AddToFavourite(int id)
        {
            if (await _locationService.AddToFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }

        [HttpDelete("RemoveFavourite/{id}")]
        public async Task<IActionResult> RemoveFavourite(int id)
        {
            if (await _locationService.RemoveFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }
    }
}
