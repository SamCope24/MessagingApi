using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MessagingController : ControllerBase
    {
        [HttpGet("getMessage")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> GetMessage()
        {
            return Ok("Welcome to the messaging system");
        }

        [HttpGet("getSecretMessage")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> GetSecretMessage()
        {
            return Ok("Welcome to secret the messaging system");
        }
    }
}