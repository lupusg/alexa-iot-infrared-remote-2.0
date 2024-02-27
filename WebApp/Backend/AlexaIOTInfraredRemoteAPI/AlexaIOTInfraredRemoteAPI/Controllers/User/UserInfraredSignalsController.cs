using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.DTOs;
using AlexaIOTInfraredRemoteAPI.Domain.Exceptions;
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
        public async Task<ActionResult<List<InfraredSignalDTO>>> GetInfraredSignals()
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

        [HttpPut]
        public async Task<IActionResult> UpdateInfraredSignal(InfraredSignalDTO infraredSignalUpdate)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                await _userService.UpdateInfraredSignal(new Guid(userId), infraredSignalUpdate);
                return Ok();
            }
            catch (InfraredOutputAlreadyExistsException)
            {
                return Conflict("Infrared Output already exists.");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInfraredSignal(InfraredSignalDTO infraredSignalDelete)
        {
            var userId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (userId == null)
            {
                return Unauthorized();
            }

            try
            {
                await _userService.DeleteInfraredSignal(new Guid(userId), infraredSignalDelete);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred");
            }
        }

    }
}
