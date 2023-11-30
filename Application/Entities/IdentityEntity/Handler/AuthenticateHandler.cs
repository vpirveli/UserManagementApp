using Application.DTOs;
using Domain.Models;
using Domain.Utilities;
using Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.IdentityEntity.Handler
{
    public class AuthenticateHandler
    {
        private readonly UserDbContext _userDbContext; // Replace with your actual DbContext type

        public AuthenticateHandler(UserDbContext context)
        {
            _userDbContext = context;
        }

        public string Authenticate(LoginModel model)
        {
            var user = _userDbContext.Users.SingleOrDefault(x => x.UserName == model.UserName);

            if (user is null || !user.Password.Equals(model.Password.ComputeMD5Hash()))
            {
                throw new ArgumentException("Username or password is incorrect");
            }

            var token = GenerateJwtToken(user); // Assuming you have this method implemented
            return token;
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
