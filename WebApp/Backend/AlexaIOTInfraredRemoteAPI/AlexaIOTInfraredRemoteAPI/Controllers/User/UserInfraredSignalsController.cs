using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlexaIOTInfraredRemoteAPI.Controllers.User
{
    [Route("api/infrared/signals")]
    [ApiController]
    [Authorize]
    public class UserInfraredSignalsController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserInfraredSignalsController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InfraredSignal>>> GetInfraredSignals()
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                var infraredSignals = await _userService.GetInfraredSignals(new Guid(userId));
                return Ok(infraredSignals);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred");
            }

        }
    }
}
