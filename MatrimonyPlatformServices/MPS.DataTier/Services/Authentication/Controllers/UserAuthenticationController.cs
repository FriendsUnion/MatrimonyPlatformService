using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MPS.Shared.Extensions;

namespace Authentication.Controllers
{
    [ApiController]
    public class UserAuthenticationController : ControllerBase
    {
        private ILogger<UserAuthenticationController> _logger;
        public UserAuthenticationController(ILogger<UserAuthenticationController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [Route("api/user/authenticate")]
        [HttpGet]
        public IActionResult Authenticate()
        {
            using (_logger.BeginScope("UserAuthenticationController", "Authenticate"))
            {
                _logger.LogInformation("Authenticate called.");
                return Ok();
            }
        }
    }
}