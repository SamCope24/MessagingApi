using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Api.Models.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SecurityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("createToken")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> CreateToken(User user)
        {
            if (IsValidUser(user))
            {
                var tokenDescriptor = BuildTokenDescriptor(user);
                var jwtToken = BuildJwtToken(tokenDescriptor);
                return Ok(jwtToken);
            }

            return Unauthorized();
        }

        private static bool IsValidUser(User user)
        {
            return user.UserName == "sam" && user.Password == "changeme";
        }

        private SecurityTokenDescriptor BuildTokenDescriptor(User user)
        {
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"])),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };
        }

        private static string BuildJwtToken(SecurityTokenDescriptor tokenDescriptor)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}