using GideonMarket.UseCases.Handlers.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GideonMarket.Web.Server.IdentityServer
{
    public class AuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        private UserResponse CreateToken(UserLoginDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.RoleName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthSettings:Key").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration.GetSection("AuthSettings:ExpiresMin").Value)),
                SigningCredentials = creds,
                Audience = _configuration.GetSection("AuthSettings:Audience").Value,
                Issuer = _configuration.GetSection("AuthSettings:Issuer").Value
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return new UserResponse { Token = tokenHandler.WriteToken(token), ExpiredDate = tokenDescriptor.Expires, Name = user.Login, UserName = user.Login, Role = user.RoleName };
        }
        public UserResponse Login(UserLoginDto model)
        {
            return CreateToken(model);
        }
    }
}
