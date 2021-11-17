using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IConfiguration _config;

        public AccountController(IUserService userService, ICurrentUserService currentUserService, IConfiguration config )
        {
            _userService = userService;
            _currentUserService = currentUserService;
            _config = config;
        }

        //[HttpPost]
        //[Route("register")]
        //public async Task<IActionResult> Register([FromBody] UserRegisterRequestModel requestModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Ok(createdUser);
        //    }
        //    return BadRequest("Please check the data you entered")
        //}

        //[HttpPost("login")]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestModel model)
        {
            var user = await _userService.LoginUser(model);
            if(user == null)
            {
                return Unauthorized();
            }
            // un/pw is valid 
            // create JWTand send it to client(Angular) , add claims info in the token 
            return Ok(new { token = GenerateJWT(user) });
        }

        private string GenerateJWT(UserLoginResponseModel user)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Convert.ToString(user.Id)),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName)
            };

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            // get the secret key for signing the token 
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["secretKey"]));

            // specify the algorithm to sign the token 
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var expires = DateTime.UtcNow.AddHours(_config.GetValue<int>("ExpirationHours"));

            // creating the token System.IdetityModel.Tokens.Jwt
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _config["Issuer"],
                Audience = _config["Audience"]

            };

            var encodedJwt = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodedJwt);
        }

    }
}
