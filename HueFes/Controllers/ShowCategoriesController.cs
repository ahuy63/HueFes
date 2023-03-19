using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowCategoriesController : ControllerBase
    {
        public IShowCategoryService _showCategoryService { get; set; }
        public readonly IMapper _mapper;
        public ShowCategoriesController(IShowCategoryService showCategoryService, IMapper mapper)
        {
            _showCategoryService = showCategoryService;
            _mapper = mapper;
        }

        [HttpGet("GetAllShowCate")]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<IEnumerable<ShowCategoryVM>>(await _showCategoryService.GetAll()));

        //[HttpGet("GetById/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{
        //    var result = await _showCategoryService.GetById(id);
        //    if (result != null)
        //    {
        //        return Ok(_mapper.Map<ShowCategoryVM_Detail>(result));
        //    }
        //    return NotFound();
        //}

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew (ShowCategoryVM_Input input)
        {
            if (await _showCategoryService.Add(_mapper.Map<ShowCategory>(input)))
            {
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            if (await _showCategoryService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update (int id, ShowCategoryVM_Input input)
        {
            var showCate = await _showCategoryService.GetById(id);
            _mapper.Map<ShowCategoryVM_Input, ShowCategory>(input, showCate);
            if (await _showCategoryService.Update(showCate))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest();
        }
    }
}
