using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpGet]
        [Route("infrared-signal/{infraredSignalOutput}")]
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

        [HttpPost]
        [Route("infrared-signal")]
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
                return BadRequest("An error occurred");
            }
        }
    }
}