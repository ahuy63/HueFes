using AutoMapper;
using HueFes.Core.IServices;
using HueFes.Models;
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
        private readonly IConfiguration _configuration;
        public readonly IMapper _mapper;
        public static string? _otp; 

        public AuthenController(ICustomerService customerService, IMapper mapper, IConfiguration configuration)
        {
            _customerService = customerService;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(CustomerVM_Login input)
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

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CustomerVM_Create input)
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

        
        [HttpGet("GetOTP")]
        public async Task<IActionResult> GetOTP()
        {
            _otp = new Random().Next(0, 9999).ToString("D4");
            return Ok(_otp);
        }


        private string GenerateJwtToken(Customer customer)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("JwtConfig:Secret").Value);
            var tokenDecriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("TokenId", Guid.NewGuid().ToString()),
                    new Claim("Phone", customer.Phone),
                    new Claim(ClaimTypes.Role, customer.Role)
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
