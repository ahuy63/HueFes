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
    public class NewsController : ControllerBase
    {
        public readonly IMapper _mapper;
        public INewsService _newsService { get; set; }
        public NewsController(IMapper mapper, INewsService newsService)
        {
            _mapper = mapper;
            _newsService = newsService;
        }


        [HttpGet("GetAllNews")]
        public async Task<IActionResult> GetAll()
            => Ok(_mapper.Map<IEnumerable<NewsVM>>(await _newsService.GetAll()));

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _newsService.GetById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<NewsVM_Details>(result));
            }
            return NotFound();
        }

        [HttpPost("AddNewNews")]
        public async Task<IActionResult> AddNew (NewsVM_Input input) {
            if (await _newsService.Add(_mapper.Map<News>(input)))
            {
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("DeleteNews/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _newsService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("UpdateNews/{id}")]
        public async Task<IActionResult>  Update (int id, NewsVM_Input input)
        {
            var news = await _newsService.GetById(id);
            _mapper.Map<NewsVM_Input, News>(input, news);
            if (await _newsService.Update(news))
            {
                return Ok("Update Successfully!");
            }
            return BadRequest();
        }

        [HttpPost("AddFavourite/{id}")]
        public async Task<IActionResult> AddToFavourite(int id)
        {
            if (await _newsService.AddToFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }

        [HttpDelete("RemoveFavourite/{id}")]
        public async Task<IActionResult> RemoveFavourite(int id)
        {
            if (await _newsService.RemoveFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }
    }
}
