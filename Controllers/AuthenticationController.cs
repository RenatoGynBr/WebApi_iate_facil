using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi_iate_facil.Models;

namespace WebApi_iate_facil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private IConfiguration _config;
        public AuthenticationController(IConfiguration Configuration)
        {
            _config = Configuration;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginViewModel user)
        {
            if (user == null)
            {
                return BadRequest("Request do cliente inválido");
            }
            if (user.UserName == "admin" && user.Password == "qwerty123456")
            {
                var _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var _issuer = _config["Jwt:Issuer"];
                var _audience = _config["Jwt:Audience"];

                var signinCredentials = new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(2),
                    signingCredentials: signinCredentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new { Token = tokenString });

            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
