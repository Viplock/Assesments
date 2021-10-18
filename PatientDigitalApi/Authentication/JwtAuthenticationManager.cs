using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PatientDigitalApi.Authentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
       
        private Dictionary<string, string> users = new Dictionary<string, string> { { "Vipul", "P@ssword" }, { "Pratap", "P@ssKey" } };
        private readonly string key;
        public JwtAuthenticationManager(string Key)
        {
            key = Key;
        }
        public string AuthenticateUser(string username, string passKey)
        {
            if(!users.Any(d=>d.Key==username && d.Value == passKey))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,username)
                }),
                Expires=DateTime.UtcNow.AddHours(1),
                SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
