using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotNetWebApi.Models
{
    public static class JWTHelper
    {
        public static string CreateJWT()
        { 
          var jwtTokenHandler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes("veryverysecret.....");
          var identity = new ClaimsIdentity(new Claim[]
          {
            new Claim(ClaimTypes.Role,"Admin"),
            new Claim(ClaimTypes.Name,"Chitransh"),
          });

          var credentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }
    }
}
