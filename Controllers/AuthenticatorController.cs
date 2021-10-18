using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.LabTests.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.LabTests.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthenticatorController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Login to authenticate user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        /// 
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        /// <summary>
        /// Generate authentication token
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        private string GenerateJSONWebToken(User userInfo)
        {
            Double expirationTimeMinutes = 0;
            Double.TryParse(_config["LabTests:TimeoutInMinutes"], out expirationTimeMinutes);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["LabTests:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["LabTests:Issuer"], _config["LabTests:Issuer"], null, 
                expires: DateTime.Now.AddMinutes(expirationTimeMinutes), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Authenticat user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private User AuthenticateUser(User login)
        {
            User user = null;

            if (login.Username == "se")
            {
                string securityKey = _config["LabTests:Key"];
                string secureStorePWD = _config["SecureStorePWD"];
                Common.Security security = new Common.Security();
                string pwd = security.Decrypt(secureStorePWD, securityKey);
                user = new User { Username = "se", Password = pwd };
            }
            return user;
        }
    }

}
