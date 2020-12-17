using SystemInfoCommon.Interface;
using SystemInfoCommon.Model;
using Microsoft.AspNetCore.Mvc;

namespace SystemInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticationController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Login model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);
            if (user == null) return BadRequest(new {message = " user name or password is incorrect"});

            return Ok(user);
        }
    }
}