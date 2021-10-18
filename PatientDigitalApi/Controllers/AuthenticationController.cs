using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientDigitalApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PatientDigitalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthenticationController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this._jwtAuthenticationManager = jwtAuthenticationManager;
        }
        // POST api/<AuthenticationController>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] UserCreds creds)
        {
            var token=_jwtAuthenticationManager.AuthenticateUser(creds.UserName, creds.PassKey);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
