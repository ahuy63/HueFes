using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelpMenuController : ControllerBase
    {
        public IHelpMenuService _helpMenuService { get; set; }
        public readonly IMapper _mapper;
        public HelpMenuController(IHelpMenuService helpMenuService, IMapper mapper)
        {
            _helpMenuService = helpMenuService;
            _mapper = mapper;
        }

        [HttpGet("GetAllSubMenu")]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<IEnumerable<HelpMenuVM>>(await _helpMenuService.GetAll()));

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _helpMenuService.GetById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<HelpMenuVM_Detail>(result));
            }
            return NotFound();
        }

        [HttpPost("AddNewSubMenu")]
        public async Task<IActionResult> AddNew(HelpMenuVM_Input input)
        {
            if (await _helpMenuService.Add(_mapper.Map<HelpMenu>(input)))
            {
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("DeleteSubMenu/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _helpMenuService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("UpdateSubMenu/{id}")]
        public async Task<IActionResult> Update(int id, HelpMenuVM_Input input)
        {
            var subMenu = await _helpMenuService.GetById(id);
            _mapper.Map<HelpMenuVM_Input, HelpMenu>(input, subMenu);
            if (await _helpMenuService.Update(subMenu))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest();
        }
    }
}
