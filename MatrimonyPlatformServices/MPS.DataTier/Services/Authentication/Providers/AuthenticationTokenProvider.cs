using Authentication.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MPS.Shared;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authentication.Providers
{
    public class AuthenticationTokenProvider : IAuthenticationTokenProvider
    {
        private IConfiguration _configuration;
        public AuthenticationTokenProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateAuthenticationToken(UserDetail userDetail, string requestIssuer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string privateKey = Convert.ToString(_configuration["AppSettings:SecretKey"]);

            if (string.IsNullOrWhiteSpace(privateKey))
                throw new ArgumentNullException($"{nameof(privateKey)} cannot be null or empty.");

            var key = Encoding.UTF8.GetBytes(privateKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDetail.ToString(), "combinationofuserdetail", requestIssuer)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);             
        }
    }
}
