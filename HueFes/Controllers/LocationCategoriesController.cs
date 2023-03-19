using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationCategoriesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public ILocationCategoryService _locationCategoryService { get; set; }
        public LocationCategoriesController(IMapper mapper, ILocationCategoryService locationCategoryService)
        {
            _mapper = mapper;
            _locationCategoryService = locationCategoryService;
        }

        [HttpGet("GetAllLocationCategory")]
        public async Task<IActionResult> GetAll() => Ok(_mapper.Map<IEnumerable<LocationCategoryVM>>(await _locationCategoryService.GetAll()));

        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _locationCategoryService.GetById(id);
            if (result != null) 
            {
                return Ok(_mapper.Map<LocationCategoryVM_Detail>(result));
            }
            return NotFound();
        }

        [HttpPost("AddLocationCategory")]
        public async Task<IActionResult> Add(LocationCategoryVM_Input input)
        {
            var mappedInput = _mapper.Map<LocationCategory>(input);
            if (await _locationCategoryService.Add(mappedInput))
            {
                return NoContent();
            }
            return BadRequest();
        }

        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> Update(int id, LocationCategoryVM_Input input)
        {
            var locationCate = await _locationCategoryService.GetById(id);
            _mapper.Map<LocationCategoryVM_Input, LocationCategory>(input, locationCate);
            if (await _locationCategoryService.Update(locationCate))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest("Update Failed!!!");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _locationCategoryService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }
    }
}
