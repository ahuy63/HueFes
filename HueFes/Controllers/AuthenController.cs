using AutoMapper;
using HueFes.Core.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        public ICustomerService _customerService { get; set; }
        public readonly IMapper _mapper;

        public AuthenController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


    }
}
