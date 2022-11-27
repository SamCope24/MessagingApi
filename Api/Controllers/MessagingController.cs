using Api.Persistence.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MessagingController : ControllerBase
    {
        private readonly IRepository _repository;

        public MessagingController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("read")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<string>> ReadMessages()
        {
            return _repository.Read();
        }

        [HttpPost("write")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> WriteMessage([FromBody] string message)
        {
            _repository.Write(message);
            return Ok($"Message: '{message}' written to file");
        }
    }
}