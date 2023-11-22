using AlexaIOTInfraredRemoteAPI.Domain;
using AlexaIOTInfraredRemoteAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        [HttpPost]
        [Consumes("text/plain")]
        //used by the board
        public async Task<ActionResult> CreateInfraredSignal()
        {
            using var reader = new StreamReader(Request.Body, Encoding.UTF8);
            string infraredData = await reader.ReadToEndAsync();

            var boardClientId = User?.Claims?.FirstOrDefault(c => c.Type == "sub").Value;

            //var infraredSignal = await _infraredSignalService.CreateInfraredSignal(Guid.Parse(identityUserId), request.Length, request.InfraredData);
            return Ok();
        }
    }
}
