﻿using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public IEventService _eventService { get; set; }
        public readonly IMapper _mapper;
        public EventsController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet("GetAllEvents")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<IEnumerable<EventVM>>(await _eventService.GetAll()));
        }

        [HttpGet("GetAllByTieuDiem")]
        public async Task<IActionResult> GetByTieuDiem()
            => Ok(_mapper.Map<IEnumerable<EventVM>>(await _eventService.GetByTieuDiem()));

        [HttpGet("GetAllByCongDong")]
        public async Task<IActionResult> GetByCongDong() 
            => Ok(_mapper.Map<IEnumerable<EventVM>>(await _eventService.GetByCongDong()));

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _eventService.GetById(id);
            if (result != null)
            {
                return Ok(_mapper.Map<EventVM_Detail>(result));
            }
            return NotFound();
        }

        [HttpPost("AddNew")]
        public async Task<IActionResult> AddNew(EventVM_Input input)
        {
            if (await _eventService.Add(_mapper.Map<Event>(input)))
            {
                await _eventService.AddImage(_mapper.Map<IEnumerable<EventImage>>(input.EventImages));
                return Ok("Add Successfully!!!");
            }
            return BadRequest();
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _eventService.Delete(id))
            {
                return Ok("Delete Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(int id, EventVM_Input input)
        {
            var _event = await _eventService.GetById(id);
            _mapper.Map<EventVM_Input, Event>(input, _event);
            if (await _eventService.Update(_event))
            {
                return Ok("Update Successfully!!!");
            }
            return BadRequest();
        }

        [HttpPost("AddFavourite/{id}")]
        public async Task<IActionResult> AddToFavourite(int id)
        {
            if (await _eventService.AddToFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }

        [HttpDelete("RemoveFavourite/{id}")]
        public async Task<IActionResult> RemoveFavourite(int id)
        {
            if (await _eventService.RemoveFavourite(id))
            {
                return Ok("Done");
            }
            return BadRequest();
        }
    }
}
