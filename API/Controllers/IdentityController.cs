using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.DTOs;
using Domain.Models;
using Domain.Utilities;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserDbContext _context;

        public IdentityController(UserDbContext context)
        {
            _context = context;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] LoginModel model)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserName == model.UserName);

            if (user is null || !user.Password.Equals(model.Password.ComputeMD5Hash()))
            {
                return BadRequest("Username or password is incorrect");
            }

            var token = GenerateJwtToken(user);
            return Ok(token);
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("TheKeyDefinitelyShouldNotBeHiddenHere");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

}
