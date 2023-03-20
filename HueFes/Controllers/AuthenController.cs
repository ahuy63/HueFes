using AutoMapper;
using HueFes.Core.IServices;
using HueFes.DomainModels;
using HueFes.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace HueFes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        public ICustomerService _customerService { get; set; }
        public IStaffService _staffService { get; set; }
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        public static string? _otp; 

        public AuthenController(ICustomerService customerService, IMapper mapper, IConfiguration configuration, IStaffService staffService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _configuration = configuration;
            _staffService = staffService;
        }

        //Customer Section
        [HttpPost("CustomerLogin")]
        public async Task<IActionResult> Login_Customer(CustomerVM_Login input)
        {
            var customer = await _customerService.GetByPhone(input.Phone);

            if (customer != null && input.OTP == _otp)
            {
                _otp = "";
                return Ok("Login Successfully!!!\nToken: " + GenerateJwtToken(customer));
            }
            if (customer == null && input.OTP == _otp)
            {
                _otp = "";
                return Ok("New User, Proceed to Create User!!!" + new { Phone = input.Phone });
            }
            return BadRequest("Wrong OTP");
        }

        [HttpPost("CustomerCreate")]
        public async Task<IActionResult> Create_Customer(CustomerVM_Create input)
        {
            if (await _customerService.GetByEmail(input.Email) != null)
            {
                return Ok("Email is already existed!!!");
            }
            var result = await _customerService.Add(_mapper.Map<Customer>(input));
            if (result != null)
            {
                return Ok("Create Successfully!!!\nToken: " + GenerateJwtToken(result));
            }
            return BadRequest();
        }


        //Staff Section
        [HttpPost("StaffLogin")]
        public async Task<IActionResult> StaffLogin (StaffVM_Login input)
        {
            var staff = await _staffService.Login(input);
            if (staff != null) 
            {
                if (!staff.Status)
                {
                    return Ok("Account need to be activated!!!");
                }
                return Ok("Login Successfully!!!\nToken: " + GenerateJwtToken(staff));
            }
            return StatusCode(StatusCodes.Status401Unauthorized, "Wrong Credentials");
        }

        [HttpPost("StaffAccountActivation")]
        public async Task<IActionResult> StaffAccountActivation(StaffVM_Activate input)
        {
            if (input.Otp == _otp)
            {
                _otp = "";
                if (await _staffService.ActivateAccount(input.Phone))
                {
                    return Ok("Activate Successfully!!!\nPlease Login Again");
                }
                return NotFound("Account is not Existed!!!");
            }
            _otp = "";
            return BadRequest("Wrong OTP!!!\n Please get new OTP");
        }


        [HttpGet("GetOTP")]
        public async Task<IActionResult> GetOTP()
        {
            _otp = new Random().Next(0, 9999).ToString("D4");
            return Ok(_otp);
        }

        private string GenerateJwtToken(dynamic dy)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, dy.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                    new Claim("Phone", dy.Phone),
                    new Claim(ClaimTypes.Role, dy.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = jwtTokenHandler.CreateToken(tokenDecriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        private int GetCurrentUserId()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaim = identity.Claims;
                return Int32.Parse(userClaim.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
            }
            return 0;
        }
    }
}
