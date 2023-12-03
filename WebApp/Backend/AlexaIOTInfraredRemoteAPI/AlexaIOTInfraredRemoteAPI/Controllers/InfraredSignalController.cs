using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using AlexaIOTInfraredRemoteAPI.Domain.Helpers;

namespace AlexaIOTInfraredRemoteAPI.Controllers
{
    [Route("api/infrared/signals")]
    [ApiController]
    [Authorize]
    public class InfraredSignalController : ControllerBase
    {
        private readonly IUserService _userService;
        public InfraredSignalController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<InfraredSignal>>> GetInfraredSignals(string sort)
        {
            var infraredSignals = await _userService.GetInfraredSignals(sort);
            return Ok(infraredSignals);
        }

        //endpoint used by the board
        [HttpPost]
        [Consumes("text/plain")]
        public async Task<ActionResult> CreateInfraredSignal()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            var infraredDataRaw = await reader.ReadToEndAsync();
            var boardName = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (string.IsNullOrEmpty(boardName))
            {
                return Unauthorized("User not found");
            }

            try
            {
                await _userService.CreateInfraredSignal(boardName, infraredDataRaw);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Unknown error");
            }
        }
    }
}
