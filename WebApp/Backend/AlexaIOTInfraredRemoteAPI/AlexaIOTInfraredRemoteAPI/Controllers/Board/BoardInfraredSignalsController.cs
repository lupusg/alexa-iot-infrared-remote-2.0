using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlexaIOTInfraredRemoteAPI.Controllers.Board
{
    [Route("api/board")]
    [ApiController]
    [Authorize]
    public class BoardInfraredSignalsController : ControllerBase
    {
        private readonly IUserService _userService;

        public BoardInfraredSignalsController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("infrared-signal/{infraredSignalOutput}")]
        [HttpGet]
        public async Task<ActionResult> GetInfraredSignal([FromRoute] string infraredSignalOutput)
        {
            var clientId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            if (clientId == null)
            {
                return Unauthorized();
            }

            try
            {
                var infraredSignal = await _userService.GetInfraredSignalByOutput(clientId, infraredSignalOutput);
                var infraredData = infraredSignal.InfraredData;

                byte[] buffer = new byte[infraredData.Length * sizeof(ushort) + sizeof(ushort)];
                Buffer.BlockCopy(new ushort[] { (ushort)infraredData.Length }, 0, buffer, 0, sizeof(ushort));
                Buffer.BlockCopy(infraredData, 0, buffer, sizeof(ushort), infraredData.Length * sizeof(ushort));

                return File(buffer, "application/octet-stream");
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred");
            }
        }
    }
}