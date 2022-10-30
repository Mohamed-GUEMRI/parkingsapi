using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sharedProject.IDAO;
using sharedProject.model;

namespace WebAPI_Parking.Controllers
{
    //[ApiController]
    [Route("api/[controller]")]
    [TokenAuthenticationFilter]
    public class AuthentifController : ControllerBase
    {
        private ITokenManager tokenManager;
        public AuthentifController(TokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        [HttpGet]
        public IActionResult Authentificate([FromBody] string user, [FromBody] string pswd)
        {
            if (tokenManager.Authentificate(user, pswd))
            {
                return Ok(tokenManager.NewToken());
            }
            else
            {
                ModelState.AddModelError("Unauthorised", "You are authorised");
                return BadRequest();
            }

        }
    }
}
