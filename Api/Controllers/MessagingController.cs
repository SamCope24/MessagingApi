using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.IO.File;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MessagingController : ControllerBase
    {
        [HttpGet("welcome")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> GetWelcomeMessage()
        {
            return Ok("Welcome to the messaging system");
        }

        [HttpPost("write")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> WriteMessage([FromBody] string message)
        {
            AppendAllTextAsync("logs.txt", message + '\n');
            return Ok($"Message: '{message}' written to file");
        }
    }
}