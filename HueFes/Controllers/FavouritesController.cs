using AutoMapper;
using HueFes.Core.IServices;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        public readonly IMapper _mapper;
        public IFavouriteService _favouriteService { get; set; }
        public FavouritesController(IMapper mapper, IFavouriteService favouriteService)
        {
            _mapper = mapper;
            _favouriteService = favouriteService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _favouriteService.GetAll());
        }
    }
}
